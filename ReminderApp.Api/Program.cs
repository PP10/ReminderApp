using ReminderApp.Api.Requests;
using ReminderApp.Application.Interfaces;
using ReminderApp.Domain;
using ReminderApp.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddSingleton<IReminderRepository, InMemoryReminderRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapGet("/reminders", (IReminderRepository repository) =>
{
    var reminders =  repository.GetAll();
    return Results.Ok(reminders);
});


app.MapPost("/reminders", (CreateReminderRequest request, IReminderRepository repository) =>
{
   var reminder = new Reminder
   {
     Id = Guid.NewGuid(),
     Title = request.Title,
     Description = request.Description,
     DueDate = request.DueDate
   };

    repository.Add(reminder);
    return  Results.Created($"/reminders/{reminder.Id}", reminder);
});

app.Run();

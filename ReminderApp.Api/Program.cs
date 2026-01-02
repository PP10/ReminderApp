using ReminderApp.Application.Interfaces;
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

app.Run();

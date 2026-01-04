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

    try
    {
        reminder.Validate();
    }
    catch (ArgumentException ex)
    {
        return Results.BadRequest(new {error = ex.Message});
    }

    repository.Add(reminder);
    return  Results.Created($"/reminders/{reminder.Id}", reminder);
});

app.MapPut("/reminders/{id:guid}", (Guid id, UpdateReminderRequest request, IReminderRepository repository) =>
{
    var existing = repository.GetAll().First();
    if (existing is null)
    {
        return Results.NotFound();
    }

    existing.Title = request.Title;
    existing.Description = request.Description;
    existing.DueDate = request.DueDate;
    existing.IsCompleted = request.IsComplet;

    try
    {
        existing.Validate();
    }
    catch(ArgumentException ex)
    {
        return Results.BadRequest(new {error = ex.Message});
    }
    
    repository.Update(existing);

    return Results.Ok(existing);
});

app.MapDelete("/reminders/{id:guid}", (Guid id, IReminderRepository repository) =>
{
    var existing = repository.GetById(id);
    if (existing is null)
    {
        return Results.NotFound();
    }

    repository.Delete(id);
    return Results.NoContent();
});
app.Run();

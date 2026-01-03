namespace ReminderApp.Api.Requests;
public record CreateReminderRequest(string Title, string? Description, DateTime DueDate);
namespace ReminderApp.Api.Requests;

public record UpdateReminderRequest(string Title, string? Description, DateTime DueDate, bool IsComplet);
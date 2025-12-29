namespace ReminderApp.Domain;

public class Reminder
{
    public Guid Id {get; set;} = Guid.NewGuid();
    public string Title {get; set;} = string.Empty;
    public string? Description {get; set;}
    public DateTime DueDate {get; set;}
    public bool IsCompleted {get; set;}
}

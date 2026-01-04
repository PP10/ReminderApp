namespace ReminderApp.Domain;

public class Reminder
{
    public Guid Id {get; set;} = Guid.NewGuid();
    public string Title {get; set;} = string.Empty;
    public string? Description {get; set;}
    public DateTime DueDate {get; set;}
    public bool IsCompleted {get; set;}

    public void Validate()
    {
        if (string.IsNullOrWhiteSpace(Title))
        {
            throw new ArgumentException("Title is required.");
        }
        if (DueDate < DateTime.UtcNow)
        {
            throw new ArgumentException("DueDate cannot be in the past.");
        }
    }
}

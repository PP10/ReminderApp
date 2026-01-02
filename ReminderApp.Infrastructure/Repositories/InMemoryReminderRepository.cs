using ReminderApp.Application.Interfaces;
using ReminderApp.Domain;

namespace ReminderApp.Infrastructure.Repositories;

public class InMemoryReminderRepository : IReminderRepository
{
    private readonly List<Reminder> _reminders = new();
    public void Add(Reminder reminder)
    {
        _reminders.Add(reminder);
    }

    public IEnumerable<Reminder> GetAll()
    {
        return _reminders;
    }
}
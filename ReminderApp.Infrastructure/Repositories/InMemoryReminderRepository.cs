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

    public void Delete(Guid id)
    {
        var reminder = GetById(id);
        if(reminder is not null)
        {
            _reminders.Remove(reminder);
        }
    }

    public IEnumerable<Reminder> GetAll()
    {
        return _reminders;
    }

    public Reminder? GetById(Guid id) => _reminders.FirstOrDefault(r => r.Id == id);
    

    public void Update(Reminder reminder)
    {
        var index = _reminders.FindIndex(r => r.Id == reminder.Id);
        if(index != 0)
        {
            _reminders[index] = reminder;
        }
    }
}
using ReminderApp.Domain;
namespace ReminderApp.Application.Interfaces;

public interface IReminderRepository
{
    void Add(Reminder reminder);
    IEnumerable<Reminder> GetAll();
    Reminder? GetById(Guid id);
    void Update(Reminder reminder);
    void Delete(Guid id);
}


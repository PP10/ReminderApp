using ReminderApp.Domain;
namespace ReminderApp.Application.Interfaces;

public interface IReminderRepository
{
    IEnumerable<Reminder> GetAll();
    void Add(Reminder reminder);
}
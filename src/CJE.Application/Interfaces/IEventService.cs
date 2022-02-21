using CJE.Application.Dtos;
using System.Threading.Tasks;

namespace CJE.Application.Interfaces
{
    public interface IEventService
    {
        Task<bool> AddEvent(int userId, EventDto @event);
        Task<bool> UpdateEvent(int userId, int id, EventDto @event);
        Task<bool> DeleteEvent(int userId, int idEvent);

        Task<EventDto[]> GetAllEventsByThemeAsync(int userId, string theme, bool includeSpeakers);
        Task<EventDto[]> GetAllEventsAsync(int userId, bool includeSpeakers);
        Task<EventDto> GetEventByIdAsync(int userId, int Id, bool includeSpeakers);

        
    }
}

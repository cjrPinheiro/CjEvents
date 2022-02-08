using CJE.Aplication.Dtos;
using System.Threading.Tasks;

namespace CJE.Aplication.Interfaces
{
    public interface IEventService
    {
        Task<bool> AddEvent(EventDto @event);
        Task<bool> UpdateEvent(EventDto @event);
        Task<bool> DeleteEvent(int idEvent);

        Task<EventDto[]> GetAllEventsByThemeAsync(string theme, bool includeSpeakers);
        Task<EventDto[]> GetAllEventsAsync(bool includeSpeakers);
        Task<EventDto> GetEventByIdAsync(int Id, bool includeSpeakers);

        
    }
}

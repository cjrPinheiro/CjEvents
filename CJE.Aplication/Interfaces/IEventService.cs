using CJE.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CJE.Aplication.Interfaces
{
    public interface IEventService
    {
        Task<bool> AddEvent(Event @event);
        Task<bool> UpdateEvent(Event @event);
        Task<bool> DeleteEvent(int idEvent);

        Task<Event[]> GetAllEventsByThemeAsync(string theme, bool includeSpeakers);
        Task<Event[]> GetAllEventsAsync(bool includeSpeakers);
        Task<Event> GetEventByIdAsync(int Id, bool includeSpeakers);

        
    }
}

using CJE.Domain.Entities;
using CJE.Persistence.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CJE.Persistence.Interfaces
{
    public interface IEventPersist : IBasePersist<Event>
    {
        Task<Event[]> GetAllEventsByThemeAsync(int userId, string theme, bool includeSpeakers);
        Task<Event[]> GetAllEventsAsync(int userId, bool includeSpeakers);
        Task<Event> GetEventByIdAsync(int userId, int Id, bool includeSpeakers);
    }
}

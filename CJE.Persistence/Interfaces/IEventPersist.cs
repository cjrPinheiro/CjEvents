using CJE.Domain.Entities;
using CJE.Persistence.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CJE.Persistence.Interfaces
{
    public interface IEventPersist : IBasePersist
    {
        Task<Event[]> GetAllEventsByThemeAsync(string theme, bool includeSpeakers);
        Task<Event[]> GetAllEventsAsync(bool includeSpeakers);
        Task<Event> GetEventByIdAsync(int Id, bool includeSpeakers);
    }
}

using CJE.Aplication.Interfaces;
using CJE.Domain.Entities;
using CJE.Persistence.Interfaces;
using System;
using System.Threading.Tasks;
using CJE.Common.Exceptions;

namespace CJE.Aplication.Services
{
    public class EventService : IEventService
    {
        private readonly IEventPersist _eventRepository;

        public EventService(IEventPersist eventPersist)
        {
            _eventRepository = eventPersist;
        }
        public async Task<bool> AddEvent(Event @event)
        {
            try
            {
                await _eventRepository.AddAsync(@event);
                return await _eventRepository.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }

           
        }
        public async Task<bool> UpdateEvent(Event @event)
        {
            try
            {
                //verificar existencia do item
                var existEvent = await _eventRepository.GetEventByIdAsync(@event.Id, false);
                if (existEvent == null) throw new DataNotFoundException($"EventId: {@event.Id} not found in database.");

                _eventRepository.Update(@event);
                return await _eventRepository.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw;
            }
        }
        public async Task<bool> DeleteEvent(int idEvent)
        {
            try
            {
                Event delEvent = await _eventRepository.GetEventByIdAsync(idEvent, false);

                if (delEvent == null) throw new DataNotFoundException($"EventId: {idEvent} not found in database.");

                _eventRepository.Delete(delEvent);
                return await _eventRepository.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }     
        }

        public async Task<Event[]> GetAllEventsAsync(bool includeSpeakers = false)
        {
            try
            {
                return await _eventRepository.GetAllEventsAsync(includeSpeakers);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Event[]> GetAllEventsByThemeAsync(string theme, bool includeSpeakers = false)
        {
            try
            {
                return await _eventRepository.GetAllEventsByThemeAsync(theme,includeSpeakers);
            }
            catch (Exception)
            {
                throw;
            }     
        }

        public async Task<Event> GetEventByIdAsync(int Id, bool includeSpeakers = false)
        {
            try
            {
                return await _eventRepository.GetEventByIdAsync(Id, includeSpeakers);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

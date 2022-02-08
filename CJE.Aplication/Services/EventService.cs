using CJE.Aplication.Interfaces;
using CJE.Persistence.Interfaces;
using System;
using System.Threading.Tasks;
using CJE.Common.Exceptions;
using CJE.Aplication.Dtos;
using CJE.Domain.Entities;
using AutoMapper;
using System.Collections.Generic;

namespace CJE.Aplication.Services
{
    public class EventService : IEventService
    {
        private readonly IEventPersist _eventRepository;
        private readonly IMapper _mapper;

        public EventService(IEventPersist eventPersist, IMapper mapper)
        {
            _eventRepository = eventPersist;
            _mapper = mapper;
        }
        public async Task<bool> AddEvent(EventDto @event)
        {
            Event newEvent = null;
            try
            {
                newEvent = _mapper.Map<Event>(@event);
                await _eventRepository.AddAsync(newEvent);
                return await _eventRepository.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }


        }
        public async Task<bool> UpdateEvent(EventDto @event)
        {
            
            try
            {
                var existEvent = await _eventRepository.GetEventByIdAsync(@event.Id, false);
                if (existEvent == null) throw new DataNotFoundException($"EventId: {@event.Id} not found in database.");

                _mapper.Map(@event, existEvent);
            

                _eventRepository.Update(existEvent);
                return await _eventRepository.SaveChangesAsync();
            }
            catch (Exception)
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

        public async Task<EventDto[]> GetAllEventsAsync(bool includeSpeakers = false)
        {
            EventDto[] eventsRes = null;
            try
            {
                var events = await _eventRepository.GetAllEventsAsync(includeSpeakers);
                eventsRes = _mapper.Map<EventDto[]>(events);
                return eventsRes;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<EventDto[]> GetAllEventsByThemeAsync(string theme, bool includeSpeakers = false)
        {
            EventDto[] eventsRes = null;
            try
            {
                var events = await _eventRepository.GetAllEventsByThemeAsync(theme, includeSpeakers);
                eventsRes = _mapper.Map<EventDto[]>(events);
                return eventsRes;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<EventDto> GetEventByIdAsync(int Id, bool includeSpeakers = false)
        {
            EventDto eventRes = null;
            try
            {
                var events = await _eventRepository.GetEventByIdAsync(Id, includeSpeakers);
                eventRes = _mapper.Map<EventDto>(events);
                return eventRes;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

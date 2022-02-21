using CJE.Application.Interfaces;
using CJE.Persistence.Interfaces;
using System;
using System.Threading.Tasks;
using CJE.Common.Exceptions;
using CJE.Application.Dtos;
using CJE.Domain.Entities;
using AutoMapper;
using System.Collections.Generic;

namespace CJE.Application.Services
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
        public async Task<bool> AddEvent(int userId, EventDto @event)
        {
            Event newEvent = null;
            
            try
            {
                newEvent = _mapper.Map<Event>(@event);
                newEvent.UserId = userId;
                await _eventRepository.AddAsync(newEvent);
                return await _eventRepository.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }


        }
        public async Task<bool> UpdateEvent(int userId, int id, EventDto @event)
        {
            
            try
            {
                var existEvent = await _eventRepository.GetEventByIdAsync(userId, id, false);
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
        public async Task<bool> DeleteEvent(int userId, int idEvent)
        {
            try
            {
                Event delEvent = await _eventRepository.GetEventByIdAsync(userId, idEvent, false);

                if (delEvent == null) throw new DataNotFoundException($"EventId: {idEvent} not found in database.");

                _eventRepository.Delete(delEvent);
                return await _eventRepository.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<EventDto[]> GetAllEventsAsync(int userId, bool includeSpeakers = false)
        {
            EventDto[] eventsRes = null;
            try
            {
                var events = await _eventRepository.GetAllEventsAsync(userId,includeSpeakers);
                eventsRes = _mapper.Map<EventDto[]>(events);
                return eventsRes;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<EventDto[]> GetAllEventsByThemeAsync(int userId, string theme, bool includeSpeakers = false)
        {
            EventDto[] eventsRes = null;
            try
            {
                var events = await _eventRepository.GetAllEventsByThemeAsync(userId,theme, includeSpeakers);
                eventsRes = _mapper.Map<EventDto[]>(events);
                return eventsRes;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<EventDto> GetEventByIdAsync(int userId, int Id, bool includeSpeakers = false)
        {
            EventDto eventRes = null;
            try
            {
                var events = await _eventRepository.GetEventByIdAsync(userId, Id, includeSpeakers);
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

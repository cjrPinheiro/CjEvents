using CJE.Domain.Entities;
using CJE.Persistence.Interfaces;
using CJE.Persistence.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CJE.Persistence
{
    public class SpeakerPersist : BasePersist,ISpeakerPersist
    {
  
        public SpeakerPersist(CjEventsContext context) : base(context) {}
        
        public async Task<Event> GetEventByIdAsync(int Id, bool includeSpeakers)
        {
            IQueryable<Event> query = _context.Events
                .Include(e => e.Batches)
                .Include(e => e.SocialNetworks);

            if (includeSpeakers)
            {
                query = query.Include(e => e.SpeakerEvents)
                    .ThenInclude(pe => pe.Speaker);
            }

            query = query.OrderBy(e => e.Id).Where(q=> q.Id == Id);

            return await query.AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<Event[]> GetAllEventsAsync(bool includeSpeakers)
        {
            IQueryable<Event> query = _context.Events
                .Include(e => e.Batches)
                .Include(e => e.SocialNetworks);

            if (includeSpeakers)
            {
                query = query.Include(e => e.SpeakerEvents)
                    .ThenInclude(pe => pe.Speaker);
            }

            query = query.OrderBy(e => e.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Event[]> GetAllEventsByThemeAsync(string theme, bool includeSpeakers)
        {
            IQueryable<Event> query = _context.Events
                .Include(e => e.Batches)
                .Include(e => e.SocialNetworks);

            if (includeSpeakers)
            {
                query.Include(e => e.SpeakerEvents)
                    .ThenInclude(pe => pe.Speaker);
            }

            query = query.OrderBy(e => e.Id).Where(q => q.Theme.ToLower().Contains(theme.ToLower()));

            return await query.ToArrayAsync();
        }

        public async Task<Speaker> GetSpeakerByIdAsync(int Id, bool includeEvents)
        {
            IQueryable<Speaker> query = _context.Speakers
               .Include(e => e.SocialNetworks);

            if (includeEvents)
            {
                query.Include(e => e.SpeakerEvents)
                    .ThenInclude(pe => pe.Event);
            }

            query = query.OrderBy(e => e.Id).Where(q => q.Id == Id);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Speaker[]> GetAllSpeakersAsync(bool includeEvents)
        {
            IQueryable<Speaker> query = _context.Speakers
                .Include(e => e.SocialNetworks);

            if (includeEvents)
            {
                query.Include(e => e.SpeakerEvents)
                    .ThenInclude(pe => pe.Event);
            }

            query = query.OrderBy(e => e.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Speaker[]> GetAllSpeakersByNameAsync(string name, bool includeEvents)
        {
            IQueryable<Speaker> query = _context.Speakers
                .Include(e => e.SocialNetworks);

            if (includeEvents)
            {
                query.Include(e => e.SpeakerEvents)
                    .ThenInclude(pe => pe.Event);
            }

            query = query.OrderBy(e => e.Id).Where(q=>q.Name.ToLower().Contains(name.ToLower()));

            return await query.ToArrayAsync();
        }
    }
}

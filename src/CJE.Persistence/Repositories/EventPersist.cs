using CJE.Domain.Entities;
using CJE.Persistence.Interfaces;
using CJE.Persistence.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CJE.Persistence.Repositories
{
    public class EventPersist : BasePersist<Event>, IEventPersist
    {
        public EventPersist(CjEventsContext context) : base(context) {}
        public async Task<Event> GetEventByIdAsync(int userId, int Id, bool includeSpeakers)
        {
            IQueryable<Event> query = _context.Events
                .Include(e => e.Batches)
                .Include(e => e.SocialNetworks)
                .Include(e => e.User);

            if (includeSpeakers)
            {
                query = query.Include(e => e.SpeakerEvents)
                    .ThenInclude(pe => pe.Speaker);
            }

            query = query.OrderBy(e => e.Id).Where(q=> q.Id == Id && q.UserId == userId);

            return await query.AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<Event[]> GetAllEventsAsync(int userId, bool includeSpeakers)
        {
            IQueryable<Event> query = _context.Events
                .Include(e => e.Batches)
                .Include(e => e.SocialNetworks);

            if (includeSpeakers)
            {
                query = query.Include(e => e.SpeakerEvents)
                    .ThenInclude(pe => pe.Speaker);
            }

            query = query.OrderBy(e => e.Id).Where(q=>q.UserId == userId);

            return await query.ToArrayAsync();
        }

        public async Task<Event[]> GetAllEventsByThemeAsync(int userId, string theme, bool includeSpeakers)
        {
            IQueryable<Event> query = _context.Events
                .Include(e => e.Batches)
                .Include(e => e.SocialNetworks);

            if (includeSpeakers)
            {
                query.Include(e => e.SpeakerEvents)
                    .ThenInclude(pe => pe.Speaker);
            }

            query = query.OrderBy(e => e.Id).Where(q => q.Theme.ToLower().Contains(theme.ToLower()) && q.UserId==userId);

            return await query.ToArrayAsync();
        }
    }
}

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
    public class SpeakerPersist : BasePersist<Speaker>,ISpeakerPersist
    {
  
        public SpeakerPersist(CjEventsContext context) : base(context) {}
        
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

using CJE.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CJE.Persistence
{
    public class CjEventsContext : DbContext
    {
        public CjEventsContext(DbContextOptions<CjEventsContext> dbContextOptions) : base(dbContextOptions)
        {

        }
        public DbSet<Event> Events { get; set; }
        public DbSet<Speaker> Speakers { get; set; }
        public DbSet<SpeakerEvent> SpeakerEvents { get; set; }
        public DbSet<SocialNetwork> SocialNetworks { get; set; }
        public DbSet<Batch> Batches { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SpeakerEvent>()
                .HasKey(pe => new { pe.EventId, pe.SpeakerId });

            modelBuilder.Entity<Event>()
                .HasMany(e => e.SocialNetworks)
                .WithOne(sn => sn.Event)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Speaker>()
                .HasMany(s => s.SocialNetworks)
                .WithOne(sn => sn.Speaker)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}

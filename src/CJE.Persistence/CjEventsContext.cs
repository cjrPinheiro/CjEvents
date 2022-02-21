using CJE.Domain.Entities;
using CJE.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CJE.Persistence
{
    public class CjEventsContext : IdentityDbContext<User,Role,int, IdentityUserClaim<int>, UserRole, IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>>
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
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserRole>(userRole =>
            {
                userRole.HasKey(ur => new { ur.UserId, ur.RoleId });
                userRole.HasOne(ur => ur.Role)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur=> ur.RoleId)
                    .IsRequired();

                userRole.HasOne(ur => ur.User)
                    .WithMany(u => u.UserRoles)
                    .HasForeignKey(ur=> ur.UserId)
                    .IsRequired();
            });

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

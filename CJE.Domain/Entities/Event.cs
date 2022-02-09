using CJE.Domain.Base;
using CJE.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CJE.Domain.Entities
{
    [Table("Event")]
    public class Event : BaseEntity
    {
        public string Place { get; set; }
        public DateTime? Date { get; set; }
        [Required]
        [MaxLength(50)]
        public string Theme { get; set; }
        public int MaxPeople { get; set; }
        public string ImageURL { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public IEnumerable<Batch> Batches { get; set; }
        public IEnumerable<SocialNetwork> SocialNetworks { get; set; }
        public IEnumerable<SpeakerEvent> SpeakerEvents { get; set; }
        
        

    }
}

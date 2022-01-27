using CJE.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CJE.Domain.Entities
{
    public class Event : BaseEntity
    {
        public string Place { get; set; }
        public DateTime? Date { get; set; }
        public string Theme { get; set; }
        public int MaxPeople { get; set; }
        public string ImageURL { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public IEnumerable<Batch> Batches { get; set; }
        public IEnumerable<SocialNetwork> SocialNetworks { get; set; }
        public IEnumerable<SpeakerEvent> SpeakerEvents { get; set; }
        
        

    }
}

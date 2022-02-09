using CJE.Domain.Base;
using CJE.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CJE.Domain.Entities
{
    public class Speaker : BaseEntity
    {
        public string Description { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public IEnumerable<SocialNetwork> SocialNetworks { get; set; }
        public IEnumerable<SpeakerEvent> SpeakerEvents { get; set; }
    }
}

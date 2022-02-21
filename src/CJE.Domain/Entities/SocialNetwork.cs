using CJE.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CJE.Domain.Entities
{
    public class SocialNetwork : BaseEntity
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public int? EventId { get; set; }
        public int? SpeakerId { get; set; }
        public Event Event { get; set; }
        public Speaker Speaker { get; set; }
    }
}

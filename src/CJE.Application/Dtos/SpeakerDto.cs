using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CJE.Application.Dtos
{
    public class SpeakerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PhotoUrl { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public IEnumerable<SocialNetworkDto> SocialNetworks { get; set; }
    }
}

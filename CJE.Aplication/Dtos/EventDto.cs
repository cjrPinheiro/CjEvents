using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CJE.Aplication.Dtos
{
    public class EventDto
    {
        [Required]
        public int Id { get; set; }
        public string Place { get; set; }
        public string Date { get; set; }
        [Required(ErrorMessage = "The field {0} is required.")]
        [StringLength(50,MinimumLength = 4)]
        public string Theme { get; set; }
        [Range(1, 120000)]
        public int MaxPeople { get; set; }
        [RegularExpression(@".*\.(gif|jpe?g|bmp|png)$")]
        public string ImageURL { get; set; }
        [Required]
        [Phone]
        public string Phone { get; set; }
        [Required,EmailAddress]
        public string Email { get; set; }
        public int UserId { get; set; }
        public UserDto User { get; set; }
        public IEnumerable<BatchDto> Batches { get; set; }
        public IEnumerable<SocialNetworkDto> SocialNetworks { get; set; }
    }
}

using CJE.Domain.Entities.Enum;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CJE.Domain.Entities.Identity
{
    public class User : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Title Title { get; set; }
        public string Description { get; set; }
        public Function Function { get; set; }
        public string ImageURL { get; set; }
        public IEnumerable<UserRole> UserRoles { get; set; }
        [NotMapped]
        public string FullName
        {
            get 
            {
                string res = string.Empty;
                if(string.IsNullOrWhiteSpace(FirstName) ) 
                    res = $"{this.FirstName} ";
                if (string.IsNullOrWhiteSpace(LastName)) {
                    res = $"{res}{this.LastName}";
                }
                return res;
            }
        }

    }
}

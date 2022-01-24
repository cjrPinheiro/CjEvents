using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CJE.API.Business.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Local { get; set; }
        public string Date { get; set; }
        public string Theme { get; set; }
        public int MaxPeople { get; set; }
        public string Batch { get; set; }
        public string ImageURL { get; set; }
    }
}

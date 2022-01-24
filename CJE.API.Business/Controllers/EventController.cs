using CJE.API.Business.Data;
using CJE.API.Business.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CJE.API.Business.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventController : ControllerBase
    {
        private readonly ILogger<EventController> _logger;
        private readonly DataContext _context;

        public EventController(DataContext context, ILogger<EventController> logger)
        {
            _context = context;
            _logger = logger;
        }
        [HttpGet]
        public IEnumerable<Event> Get()
        {

            return _context.Events;
        }
        [HttpGet]
        [Route("{id}")]
        public Event Get(int id)
        {
            return _context.Events.FirstOrDefault(q => q.Id == id);
        }
        [HttpPost]
        public string Post()
        {
            return "value post";
        }
        [HttpPut]
        [Route("{id}")]
        public string Put(int id)
        {
            return "value put";
        }
        [HttpDelete]
        [Route("{id}")]
        public string Delete(int id)
        {
            return "value delete";
        }
    }
}

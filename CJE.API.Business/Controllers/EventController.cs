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

        public EventController(ILogger<EventController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Event> Get()
        {

            return new List<Event>();
        }
        [HttpGet]
        [Route("{id}")]
        public Event Get(int id)
        {
            return new Event();
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

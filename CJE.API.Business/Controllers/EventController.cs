using CJE.API.Business.Models;
using CJE.Aplication.Interfaces;
using CJE.Domain.Entities;
using Microsoft.AspNetCore.Http;
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
        private readonly IEventService _eventService;
        private readonly ILogger<EventController> _logger;

        public EventController(IEventService eventService, ILogger<EventController> logger)
        {
            _eventService = eventService;
            _logger = logger;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {

            try
            {
                var events = await _eventService.GetAllEventsAsync(true);

                if (events == null)
                    return NotFound();

                return Ok(events);


            }
            catch (Exception e)
            {
                var error = GenerateError("Ocorreu um erro interno na aplicação.", e);
                //implementar log
                return this.StatusCode(StatusCodes.Status500InternalServerError, error);
            }
        }

        private GenericError GenerateError(string message, Exception exception = null)
        {
            var guid = new Guid().ToString();
            GenericError error = new(guid,  message, exception != null ? exception.Message : "");

            return error;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var @event = await _eventService.GetEventByIdAsync(id, true);

                if (@event == null)
                    return NotFound();

                return Ok(@event);
            }
            catch (Exception e)
            {
                var error = GenerateError("Ocorreu um erro interno na aplicação.", e);
                //implementar log
                return this.StatusCode(StatusCodes.Status500InternalServerError, error);
            }
        }
        [HttpGet]
        [Route("tema/{theme}")]
        public async Task<IActionResult> GetByTheme(string theme)
        {
            try
            {
                var @event = await _eventService.GetAllEventsByThemeAsync(theme, true);

                if (@event == null)
                    return NotFound();

                return Ok(@event);
            }
            catch (Exception e)
            {
                var error = GenerateError("Ocorreu um erro interno na aplicação.", e);
                //implementar log
                return this.StatusCode(StatusCodes.Status500InternalServerError, error);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Post(Event @event)
        {
            try
            {
                var newEvent = await _eventService.AddEvent(@event);

                if (!newEvent) { 
                    //implementar log
                    return BadRequest(GenerateError("Ocorreu um erro ao finalizar as alterações. Conteúdo não foi atualizado ou criado."));
                }
                return Created("","");
            }
            catch (Exception e)
            {
                var error = GenerateError("Ocorreu um erro interno na aplicação.", e);
                //implementar log
                return this.StatusCode(StatusCodes.Status500InternalServerError, error);
            }
        }
        [HttpPut]
        public async Task<IActionResult> Put(Event @event)
        {
            try
            {
                var uptEvent = await _eventService.UpdateEvent(@event);

                if (!uptEvent)
                {
                    //implementar log
                    return BadRequest(GenerateError("Ocorreu um erro ao finalizar as alterações. Conteúdo não foi atualizado ou criado."));
                }

                return Ok();
            }
            catch (Exception e)
            {
                var error = GenerateError("Ocorreu um erro interno na aplicação.", e);
                //implementar log
                return this.StatusCode(StatusCodes.Status500InternalServerError, error);
            }
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var @event = await _eventService.DeleteEvent(id);

                if (!@event)
                {
                    //implementar log
                    return this.StatusCode(StatusCodes.Status500InternalServerError, GenerateError("Ocorreu um erro ao finalizar as alterações. Conteúdo não foi atualizado ou criado."));
                }

                return Ok();
            }
            catch (Exception e)
            {
                var error = GenerateError("Ocorreu um erro interno na aplicação.", e);
                //implementar log
                return this.StatusCode(StatusCodes.Status500InternalServerError, error);
            }
        }
    }
}

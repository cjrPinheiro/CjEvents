using CJE.Application.Dtos;
using CJE.Application.Interfaces;
using CJE.Common.Extensions;
using CJE.Common.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CJE.API.Business.Controllers
{
    [Authorize]
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
                var events = await _eventService.GetAllEventsAsync(User.GetUserId(), true);
                var eventsReturn = new List<EventDto>();

                if (events == null)
                    return NoContent();

                return Ok(events);


            }
            catch (Exception e)
            {
                var error = CommonFunctions.GenerateError("Ocorreu um erro interno na aplicação.", e);
                //implementar log
                return this.StatusCode(StatusCodes.Status500InternalServerError, error);
            }
        }



        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var @event = await _eventService.GetEventByIdAsync(User.GetUserId(), id, true);

                if (@event == null)
                    return NoContent();

                return Ok(@event);
            }
            catch (Exception e)
            {
                var error = CommonFunctions.GenerateError("Ocorreu um erro interno na aplicação.", e);
                //implementar log
                return this.StatusCode(StatusCodes.Status500InternalServerError, error);
            }
        }
        [HttpGet]
        [Route("theme/{theme}")]
        public async Task<IActionResult> GetByTheme(string theme)
        {
            try
            {
                var @event = await _eventService.GetAllEventsByThemeAsync(User.GetUserId(), theme, true);

                if (@event == null)
                    return NoContent();

                return Ok(@event);
            }
            catch (Exception e)
            {
                var error = CommonFunctions.GenerateError("Ocorreu um erro interno na aplicação.", e);
                //implementar log
                return this.StatusCode(StatusCodes.Status500InternalServerError, error);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Post(EventDto @event)
        {
            try
            {
                var newEvent = await _eventService.AddEvent(User.GetUserId(), @event);

                if (!newEvent)
                {
                    //implementar log
                    return BadRequest(CommonFunctions.GenerateError("Ocorreu um erro ao finalizar as alterações. Conteúdo não foi criado."));
                }
                return Created("", "");
            }
            catch (Exception e)
            {
                var error = CommonFunctions.GenerateError("Ocorreu um erro interno na aplicação.", e);
                //implementar log
                return this.StatusCode(StatusCodes.Status500InternalServerError, error);
            }
        }
        [HttpPut]
        public async Task<IActionResult> Put(int id, EventDto @event)
        {
            try
            {
                var uptEvent = await _eventService.UpdateEvent(User.GetUserId(), id, @event);

                if (!uptEvent)
                {
                    //implementar log
                    return BadRequest(CommonFunctions.GenerateError("Ocorreu um erro ao finalizar as alterações. Conteúdo não foi atualizado."));
                }

                return Ok();
            }
            catch (Exception e)
            {
                var error = CommonFunctions.GenerateError("Ocorreu um erro interno na aplicação.", e);
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
                var @event = await _eventService.DeleteEvent(User.GetUserId(), id);

                if (!@event)
                {
                    //implementar log
                    return this.StatusCode(StatusCodes.Status500InternalServerError, CommonFunctions.GenerateError("Ocorreu um erro ao finalizar as alterações. Conteúdo não foi atualizado ou criado."));
                }

                return Ok();
            }
            catch (Exception e)
            {
                var error = CommonFunctions.GenerateError("Ocorreu um erro interno na aplicação.", e);
                //implementar log
                return this.StatusCode(StatusCodes.Status500InternalServerError, error);
            }
        }
    }
}

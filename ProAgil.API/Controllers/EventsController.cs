using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using ProAgil.Repository;
using ProAgil.Domain;

namespace ProAgil.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventsController : ControllerBase
    {
        //Injeção de Dependência
        private readonly ProAgilRepository _repository;

        public EventsController(ProAgilRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var results = await _repository.GetAllEventsAsync(true);
                return Ok(results);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Error in Data Base");
            }
        }

        [HttpGet("{EventId}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var results = await _repository.GetEventByIdAsync(id, true);
                return Ok(results);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Error in Data Base");
            }
        }

        [HttpGet("{theme}")]
        public async Task<IActionResult> Get(string theme)
        {
            try
            {
                var results = await _repository.GetAllEventsByThemeAsync(theme, true);
                return Ok(results);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Error in Data Base");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Event model)
        {
            try
            {
                _repository.Add(model));
                if (await _repository.SaveChangeAsync())
                {
                    return Created($"/api/event/{model.Id}", model)
                }
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Error in Data Base");
            }
            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> Post(int EventId, Event model)
        {
            try
            {
                var result = await _repository.GetEventByIdAsync(EventId, false);
                if(result == null) return NotFound();

                _repository.Update(model);
                if (await _repository.SaveChangeAsync())
                {
                    return Created($"/api/event/{model.Id}", model));
                }
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Error in Data Base");
            }
            return BadRequest();
        }

         [HttpDelete]
        public async Task<IActionResult> Delete(int EventId)
        {
            try
            {
                var result = await _repository.GetEventByIdAsync(EventId, false);
                if(result == null) return NotFound();

                _repository.Delete(result);
                if (await _repository.SaveChangeAsync())
                {
                    return Ok();
                }
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Error in Data Base");
            }
            return BadRequest();
        }
    }
}
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using ProAgil.Repository;
using ProAgil.Domain;
using AutoMapper;
using System.Collections.Generic;
using ProAgil.API.Dtos;

namespace ProAgil.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventsController : ControllerBase
    {
        //Injeção de Dependência
        private readonly IProAgilRepository _repository;
        private readonly IMapper _mapper;

        public EventsController(IProAgilRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var events = await _repository.GetAllEventsAsync(true);
                //<IEnumerable<EventDto> pode ser também EventDto[]
                var results = _mapper.Map<IEnumerable<EventDto>>(events);
                return Ok(results);
            }
            catch (System.Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Error in Data Base: " + e.Message);
            }
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var even = await _repository.GetEventByIdAsync(id, true);
                var results = _mapper.Map<EventDto>(even);
                return Ok(results);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Error in Data Base");
            }
        }

        [HttpGet("theme/{theme}")]
        public async Task<IActionResult> Get(string theme)
        {
            try
            {
                var events = await _repository.GetAllEventsByThemeAsync(theme, true);
                var results = _mapper.Map<EventDto[]>(events);

                return Ok(results);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Error in Data Base");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(EventDto model)
        {
            try
            {
                var result = _mapper.Map<Event>(model);
                _repository.Add(result);
                if (await _repository.SaveChangeAsync())
                {
                    return Created($"/events/{model.Id}", _mapper.Map<EventDto>(result));
                }
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Error in Data Base");
            }
            return BadRequest();
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Put(int Id, Event model)
        {
            try
            {
                var result = await _repository.GetEventByIdAsync(Id, false);
                if(result == null) return NotFound();
                
                _mapper.Map(model, result);
                _repository.Update(model);

                if (await _repository.SaveChangeAsync())
                {
                    return Created($"/events/{model.Id}", _mapper.Map<EventDto>(result));
                }
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Error in Data Base");
            }
            return BadRequest();
        }

        [HttpDelete("{EventId}")]
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
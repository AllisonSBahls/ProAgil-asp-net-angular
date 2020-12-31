using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProAgil.Domain;
using ProAgil.Repository;

namespace ProAgil.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SpeakersController : ControllerBase
    {
        private readonly IProAgilRepository _repository;

        public SpeakersController(IProAgilRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("name/{Name}")]
        public async Task<IActionResult> Get(string name)
        {
            try
            {
                var result = await _repository.GetAllSpeakerByNameAsync(name, true);
                return Ok(result);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Error in Data Base");
            }

        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var result = await _repository.GetSpeakerByIdAsync(id, true);
                return Ok(result);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Error in Data Base");
            }

        }
        [HttpPost]
        public async Task<IActionResult> Post(Speaker model)
        {
            try
            {
                _repository.Add(model);
                if (await _repository.SaveChangeAsync())
                {
                    return Created($"/speakers/{model.Id}", model);
                }
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Error in Data Base");
            }
            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> Put(int EventId, Speaker model)
        {
            try
            {
                var result = await _repository.GetEventByIdAsync(EventId, false);
                if(result == null) return NotFound();

                _repository.Update(model);
                if (await _repository.SaveChangeAsync())
                {
                    return Created($"/speakers/{model.Id}", model);
                }
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Error in Data Base");
            }
            return BadRequest();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int SpeakerId)
        {
            try
            {
                var result = await _repository.GetEventByIdAsync(SpeakerId, false);
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
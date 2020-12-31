using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProAgil.Repository;

namespace ProAgil.API.Controllers
{
    [ApiController]
    [Route("controller")]
    public class SpeakersController : ControllerBase
    {
        private readonly IProAgilRepository _repository;

        public SpeakersController(IProAgilRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{Name}")]
        public async Task<IActionResult> Get(string name){
            var result = await _repository.GetAllSpeakerByNameAsync(name, true);
            return Ok(result);
        } 

    }
}
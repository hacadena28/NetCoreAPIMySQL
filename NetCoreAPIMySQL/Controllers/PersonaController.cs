using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCoreAPIMySQL.Data.Repositories;
using NetCoreAPIMySQL.Model;
using System.Threading.Tasks;

namespace NetCoreAPIMySQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        private readonly IPersonaRepository _personaRepository;
        public PersonaController(IPersonaRepository personaRepository)
        {
            _personaRepository = personaRepository;

        }

        [HttpGet]
        public async Task<IActionResult> GetAllPersonas()
        {
            return Ok(await _personaRepository.GetAllPersona());

        }
        [HttpGet("{IdPersona}")]
        public async Task<IActionResult> GetPersonaDetails(int IdPersona)
        {
            return Ok(await _personaRepository.GetPersonaDetails(IdPersona));

        }


        [HttpPost]
        public async Task<IActionResult> CreationPersona([FromBody] Persona persona)
        {
            if (persona == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _personaRepository.InsertPersona(persona);
            return Created("created", created);
        }

        [HttpPut] 
        public async Task<IActionResult> UpdatePersona([FromBody] Persona persona)
        {
            if (persona == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _personaRepository.UpdatePersona(persona);
            return NoContent();
        }
        [HttpDelete("{IdPersona}")]
        public async Task<IActionResult> DeletePersona(int IdPersona)
        {
            await _personaRepository.DeletePersona(new Persona { IdPersona = IdPersona });
            return NoContent();
        }

    }
}

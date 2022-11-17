using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCoreAPIMySQL.Data.Repositories;
using NetCoreAPIMySQL.Model;
using System.Threading.Tasks;

namespace NetCoreAPIMySQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstudianteController : ControllerBase
    {
        private readonly IEstudianteRepository _estudianteRepository;
        public EstudianteController(IEstudianteRepository estudianteRepository)
        {
            _estudianteRepository = estudianteRepository;

        }

        [HttpGet]
        public async Task<IActionResult> ConsultarEstudiantes()
        {
            return Ok(await _estudianteRepository.ConsultarEstudiantes());

        }
        [HttpGet("{IdEstudiante}")]
        public async Task<IActionResult> ConsultarEstudiante(long IdEstudiante)
        {
            return Ok(await _estudianteRepository.ConsultarEstudiante(IdEstudiante));

        }


        [HttpPost]
        public async Task<IActionResult> RegistrarEstudiante([FromBody] Estudiante estudiante)
        {
            if (estudiante == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _estudianteRepository.RegistrarEstudiante(estudiante);
            return Created("created", created);
        }

        [HttpPut] 
        public async Task<IActionResult> ModificarEstudiante([FromBody] Estudiante estudiante)
        {
            if (estudiante == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _estudianteRepository.ModificarEstudiante(estudiante);
            return NoContent();
        }
        [HttpDelete("{IdEstudiante}")]
        public async Task<IActionResult> EliminarEstudiante(long IdEstudiante)
        {
            await _estudianteRepository.EliminarEstudiante(new Estudiante { IdEstudiante = IdEstudiante });
            return NoContent();
        }

    }
}
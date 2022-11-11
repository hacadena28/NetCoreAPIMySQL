using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCoreAPIMySQL.Data.Repositories;
using NetCoreAPIMySQL.Model;
using System.Threading.Tasks;

namespace NetCoreAPIMySQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocenteController : ControllerBase
    {
        private readonly IDocenteRepository _docenteRepository;
        public DocenteController(IDocenteRepository docenteRepository)
        {
            _docenteRepository = docenteRepository;

        }

        [HttpGet]
        public async Task<IActionResult> ConsultarDocentes()
        {
            return Ok(await _docenteRepository.ConsultarDocentes());

        }
        [HttpGet("{IdDocente}")]
        public async Task<IActionResult> ConsultarDocente(int IdDocente)
        {
            return Ok(await _docenteRepository.ConsultarDocente(IdDocente));

        }


        [HttpPost]
        public async Task<IActionResult> RegistrarDocente([FromBody] Docente docente)
        {
            if (docente == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _docenteRepository.RegistrarDocente(docente);
            return Created("created", created);
        }

        [HttpPut] 
        public async Task<IActionResult> ModificarDocente([FromBody] Docente docente)
        {
            if (docente == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _docenteRepository.ModificarDocente(docente);
            return NoContent();
        }
        [HttpDelete("{IdDocente}")]
        public async Task<IActionResult> EliminarDocente(int IdDocente)
        {
            await _docenteRepository.EliminarDocente(new Docente { IdDocente = IdDocente });
            return NoContent();
        }

    }
}
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCoreAPIMySQL.Data.Repositories;
using NetCoreAPIMySQL.Model;
using System.Threading.Tasks;

namespace NetCoreAPIMySQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CasoController : ControllerBase
    {
        private readonly ICasoRepository _casoRepository;
        public CasoController(ICasoRepository casoRepository)
        {
            _casoRepository = casoRepository;

        }

        [HttpGet]
        public async Task<IActionResult> ConsultarCasos()
        {
            return Ok(await _casoRepository.ConsultarCasos());

        }
        [HttpGet("{IdCaso}")]
        public async Task<IActionResult> ConsultarCaso(int IdCaso)
        {
            return Ok(await _casoRepository.ConsultarCaso(IdCaso));

        }


        [HttpPost]
        public async Task<IActionResult> RegistrarCaso([FromBody] Caso caso)
        {
            if (caso == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _casoRepository.RegistrarCaso(caso);
            return Created("created", created);
        }

        [HttpPut] 
        public async Task<IActionResult> ModificarCaso([FromBody] Caso caso)
        {
            if (caso == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _casoRepository.ModificarCaso(caso);
            return NoContent();
        }
        [HttpDelete("{IdCaso}")]
        public async Task<IActionResult> EliminarCaso(int IdCaso)
        {
            await _casoRepository.EliminarCaso(new Caso { IdCaso = IdCaso });
            return NoContent();
        }

    }
}
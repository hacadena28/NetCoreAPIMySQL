using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCoreAPIMySQL.Data.Repositories;
using NetCoreAPIMySQL.Model;
using System.Threading.Tasks;

namespace NetCoreAPIMySQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdministradorController : ControllerBase
    {
        private readonly IAdministradorRepository _administradorRepository;
        public AdministradorController(IAdministradorRepository administradorRepository)
        {
            _administradorRepository = administradorRepository;

        }

        [HttpGet]
        public async Task<IActionResult> ConsultarAdministradors()
        {
            return Ok(await _administradorRepository.ConsultarAdministradors());

        }
        [HttpGet("{IdAdministrador}")]
        public async Task<IActionResult> ConsultarAdministrador(long IdAdministrador)
        {
            return Ok(await _administradorRepository.ConsultarAdministrador(IdAdministrador));

        }


        [HttpPost]
        public async Task<IActionResult> RegistrarAdministrador([FromBody] Administrador administrador)
        {
            if (administrador == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _administradorRepository.RegistrarAdministrador(administrador);
            return Created("created", created);
        }

        [HttpPut] 
        public async Task<IActionResult> ModificarAdministrador([FromBody] Administrador administrador)
        {
            if (administrador == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _administradorRepository.ModificarAdministrador(administrador);
            return NoContent();
        }
        [HttpDelete("{IdAdministrador}")]
        public async Task<IActionResult> EliminarAdministrador(long IdAdministrador)
        {
            await _administradorRepository.EliminarAdministrador(new Administrador { IdAdministrador = IdAdministrador });
            return NoContent();
        }

    }
}
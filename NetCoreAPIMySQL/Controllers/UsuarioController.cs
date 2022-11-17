using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCoreAPIMySQL.Data.Repositories;
using NetCoreAPIMySQL.Model;
using System.Threading.Tasks;

namespace NetCoreAPIMySQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;

        }

        [HttpGet]
        public async Task<IActionResult> ConsultarUsuarios()
        {
            return Ok(await _usuarioRepository.ConsultarUsuarios());

        }
        [HttpGet("{IdUsuario}")]
        public async Task<IActionResult> ConsultarUsuario(long IdUsuario)
        {
            return Ok(await _usuarioRepository.ConsultarUsuario(IdUsuario));

        }


        [HttpPost]
        public async Task<IActionResult> RegistrarUsuario([FromBody] Usuario usuario)
        {
            if (usuario == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _usuarioRepository.RegistrarUsuario(usuario);
            return Created("created", created);
        }

        [HttpPut] 
        public async Task<IActionResult> ModificarUsuario([FromBody] Usuario usuario)
        {
            if (usuario == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _usuarioRepository.ModificarUsuario(usuario);
            return NoContent();
        }
        [HttpDelete("{IdUsuario}")]
        public async Task<IActionResult> EliminarUsuario(long IdUsuario)
        {
            await _usuarioRepository.EliminarUsuario(new Usuario { IdUsuario = IdUsuario });
            return NoContent();
        }

    }
}

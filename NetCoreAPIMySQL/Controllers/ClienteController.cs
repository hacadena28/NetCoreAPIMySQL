using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCoreAPIMySQL.Data.Repositories;
using NetCoreAPIMySQL.Model;
using System.Threading.Tasks;

namespace NetCoreAPIMySQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteRepository _clienteRepository;
        public ClienteController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;

        }

        [HttpGet]
        public async Task<IActionResult> ConsultarClientes()
        {
            return Ok(await _clienteRepository.ConsultarClientes());

        }
        [HttpGet("{IdCliente}")]
        public async Task<IActionResult> ConsultarCliente(int IdCliente)
        {
            return Ok(await _clienteRepository.ConsultarCliente(IdCliente));

        }


        [HttpPost]
        public async Task<IActionResult> RegistrarCliente([FromBody] Cliente cliente)
        {
            if (cliente == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _clienteRepository.RegistrarCliente(cliente);
            return Created("created", created);
        }

        [HttpPut] 
        public async Task<IActionResult> ModificarCliente([FromBody] Cliente cliente)
        {
            if (cliente == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _clienteRepository.ModificarCliente(cliente);
            return NoContent();
        }
        [HttpDelete("{IdCliente}")]
        public async Task<IActionResult> EliminarCliente(int IdCliente)
        {
            await _clienteRepository.EliminarCliente(new Cliente { IdCliente = IdCliente });
            return NoContent();
        }

    }
}
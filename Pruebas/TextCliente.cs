using NetCoreAPIMySQL.Controllers;
using NetCoreAPIMySQL.Data;
using NetCoreAPIMySQL.Data.Repositories;
using NetCoreAPIMySQL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Pruebas
{
    public class TextCliente
    {
        private MySQLConfiguration _connectionString;
        private readonly UsuarioRepository _usuarioRepository;

        ClienteController controladorCliente= new ClienteController(new ClienteRepository(new MySQLConfiguration("server=localhost;port=49153;database=bdapires;uid=root;password=mysqlpw")));
        [Fact]
        public async void registrarCliente()
        {
            Cliente cliente = new Cliente();

            cliente.IdCliente = 4000000002;
            cliente.IdPersona = 4000000002;
            cliente.Direccion = "calle 4";
            cliente.Correo = "cliente2@gmail.com";
            cliente.Telefono = 3000000004;
            cliente.PrimerNombre = "Anderson";
            cliente.SegundoNombre = "Cuatro";
            cliente.PrimerApellido = "Cliente";
            cliente.SegundoApellido = "Dos";

            var result = await controladorCliente.RegistrarCliente(cliente);

            Assert.NotNull(result);
        }
    }
}

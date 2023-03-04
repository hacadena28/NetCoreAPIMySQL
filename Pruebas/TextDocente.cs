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
    public class TextDocente
    {
        private MySQLConfiguration _connectionString;
        private readonly UsuarioRepository _usuarioRepository;

        DocenteController controladorDocente= new DocenteController(new DocenteRepository(new MySQLConfiguration("server=localhost;port=49153;database=bdapires;uid=root;password=mysqlpw")));
        [Fact]
        public async void registrarDocente()
        {
            Docente docente = new Docente();

            docente.IdDocente = 2000000002;
            docente.IdPersona = 2000000002;
            docente.Direccion = "calle 2";
            docente.Correo = "Docente2@gmail.com";
            docente.Telefono = 3000000002;
            docente.PrimerNombre = "Alberto";
            docente.SegundoNombre = "Dos";
            docente.PrimerApellido = "Docente";
            docente.SegundoApellido = "Dos";
            docente.Facultad = "Ingenieria";
            var result = await controladorDocente.RegistrarDocente(docente);

            Assert.NotNull(result);
        }


    }
}

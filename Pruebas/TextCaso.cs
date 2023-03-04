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
    public class TextCaso
    {
        private MySQLConfiguration _connectionString;
        private readonly UsuarioRepository _usuarioRepository;

        CasoController controladorCaso= new CasoController(new CasoRepository(new MySQLConfiguration("server=localhost;port=49153;database=bdapires;uid=root;password=mysqlpw")));
        [Fact]
        public async void registrarCaso()
        {
            Caso caso = new Caso();

            caso.IdCaso = 2;
            caso.NombreCaso = "Caso 2";
            caso.Descripcion = "Este caso es la prueba unitaria 2";
            caso.Docente =2000000002;
            caso.Estudiante = 3000000002;
            caso.Cliente = 4000000002;
            caso.Fecha = "07/12/2022";
            caso.Estado = "REGISTRADO";

            var result = await controladorCaso.RegistrarCaso(caso);

            Assert.NotNull(result);
        }
    }
}

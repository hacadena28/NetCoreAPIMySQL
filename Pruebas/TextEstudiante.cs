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
    public class TextEstudiante
    {
        private MySQLConfiguration _connectionString;
        private readonly UsuarioRepository _usuarioRepository;

        EstudianteController controladorEstudiante= new EstudianteController(new EstudianteRepository(new MySQLConfiguration("server=localhost;port=49153;database=bdapires;uid=root;password=mysqlpw")));
        [Fact]
        public async void registrarEstudiante()
        {
            Estudiante estudiante = new Estudiante();

            estudiante.IdEstudiante = 3000000002;
            estudiante.IdPersona = 3000000002;
            estudiante.Direccion = "calle 3";
            estudiante.Correo = "Estudiante2@gmail.com";
            estudiante.Telefono = 3000000003;
            estudiante.PrimerNombre = "Orozco";
            estudiante.SegundoNombre = "Tres";
            estudiante.PrimerApellido = "Estudiante";
            estudiante.SegundoApellido = "Dos";
            estudiante.Semestre = 9;
            estudiante.Estado = "Registrado";
            var result = await controladorEstudiante.RegistrarEstudiante(estudiante);

            Assert.NotNull(result);
        }
    }
}

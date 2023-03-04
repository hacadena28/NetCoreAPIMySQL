using Microsoft.AspNetCore.Mvc;
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
    public class RegistrarAdministrador
    {

        private MySQLConfiguration _connectionString;
        private readonly UsuarioRepository _usuarioRepository;

        AdministradorController controladorAdministrador = new AdministradorController(new AdministradorRepository(new MySQLConfiguration("server=localhost;port=49153;database=bdapires;uid=root;password=mysqlpw")));
        [Fact]
        public async void registrarAdministrador()
        {
            Administrador administrador = new Administrador();

            administrador.IdAdministrador = 6;
            administrador.IdPersona = 1000000003;
            administrador.Direccion = "calle 1";
            administrador.Correo = "adfdsf@gmail.com";
            administrador.Telefono = 3000000002;
            administrador.PrimerNombre = "";
            administrador.SegundoNombre = "Uno";
            administrador.PrimerApellido = "Administrador";
            administrador.SegundoApellido = "Dos";


            CreatedResult result = (CreatedResult)await controladorAdministrador.RegistrarAdministrador(administrador);
            Assert.True(result.Location == "created");
        }
    }
}

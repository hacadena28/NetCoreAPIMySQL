using System;
using System.Xml.Serialization;
using Xunit;
using NetCoreAPIMySQL;
using Microsoft.AspNetCore.Mvc;
using NetCoreAPIMySQL.Data.Repositories;
using NetCoreAPIMySQL.Controllers;
using System.Configuration;
using NetCoreAPIMySQL.Model;
using NetCoreAPIMySQL.Data;
using MySqlX.XDevAPI.Common;
using System.Threading.Tasks;

namespace Pruebas
{
    public class RegistrarUsuario
    {
        private MySQLConfiguration _connectionString;
        private readonly UsuarioRepository _usuarioRepository;

        UsuarioController controladorUsuario = new UsuarioController(new UsuarioRepository(new MySQLConfiguration("server=localhost;port=49153;database=bdapires;uid=root;password=mysqlpw")));
        [Fact]
        public async void registrarUsuario()
        {
            Usuario user = new Usuario();
            user.IdUsuario = 1007824087;
            user.TipoUsuario = "Administrador";
            user.Correo = "hacadena@unicesar.edu.co";
            user.Contrasena = "123456";

            var result = await controladorUsuario.RegistrarUsuario(user);
        }
        [Fact]
        public async void consultarUsuario()
        {
            var result = await controladorUsuario.ConsultarUsuarios();
        }
        [Fact]
        public async void modificarUsario()
        {
            Usuario user = new Usuario();
            user.IdUsuario = 1007824087;
            user.TipoUsuario = "administrador";
            user.Correo = "testPrueba1@unicesar.edu.co";
            user.Contrasena = "123456";

            var result = await controladorUsuario.ModificarUsuario(user);
        }
        [Fact]
        public async void eliminarUsario()
        {
            var result = await controladorUsuario.EliminarUsuario(1007824087);
        }



    }
}

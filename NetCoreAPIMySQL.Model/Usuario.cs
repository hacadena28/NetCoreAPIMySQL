using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreAPIMySQL.Model
{
    public class Usuario
    {
        private int idUsuario;
        private string correo;
        private string contrasena;
        private string tipoUsuario;

        public int IdUsuario { get => idUsuario; set => idUsuario = value; }
        public string Correo { get => correo; set => correo = value; }
        public string Contrasena { get => contrasena; set => contrasena = value; }
        public string TipoUsuario { get => tipoUsuario; set => tipoUsuario = value; }
    }
}

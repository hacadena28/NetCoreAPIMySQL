using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreAPIMySQL.Model
{
    public class Usuario
    {
        private long idUsuario;
        private string correo;
        private string contrasena;
        private string tipoUsuario;

        //IdUsuario
        [Required]
        [Range(0, 9999999999, ErrorMessage = "Valor fuera de rango")]
        public long IdUsuario { get => idUsuario; set => idUsuario = value; }

        //Correo
        [Required]
        [StringLength(maximumLength:40,MinimumLength =10,ErrorMessage = "Correo no valido o fuera de rango")]

        public string Correo { get => correo; set => correo = value; }

        //Contraseña
        [Required]
        [StringLength(maximumLength:30,MinimumLength =4,ErrorMessage = "Contraseña no valida o fuera de rango")]
        public string Contrasena { get => contrasena; set => contrasena = value; }

        //Tipo Usuario
        [Required]
        [StringLength(maximumLength:20,MinimumLength =4,ErrorMessage = "Tipo de usuario no valido")]
        public string TipoUsuario { get => tipoUsuario; set => tipoUsuario = value; }
    }
}

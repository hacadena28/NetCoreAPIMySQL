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
        [Required(ErrorMessage = "Id Usuario es ogligatorio")]
        [Range(0, 9999999999, ErrorMessage = "Id Usuario es un Valor fuera de rango")]
        public long IdUsuario { get => idUsuario; set => idUsuario = value; }

        //Correo
        [Required(ErrorMessage = "Correo es ogligatorio")]
        [StringLength(maximumLength:40,MinimumLength =10,ErrorMessage = "Correo no valido o fuera de rango")]

        public string Correo { get => correo; set => correo = value; }

        //Contraseña
        [Required(ErrorMessage = "Contraseña es ogligatorio")]
        [StringLength(maximumLength:30,MinimumLength =4,ErrorMessage = "Contraseña no valida o fuera de rango")]
        public string Contrasena { get => contrasena; set => contrasena = value; }

        //Tipo Usuario
        [Required(ErrorMessage = "Tipo De Usuario es ogligatorio")]
        [StringLength(maximumLength:20,MinimumLength =4,ErrorMessage = "Tipo de usuario no valido")]
        public string TipoUsuario { get => tipoUsuario; set => tipoUsuario = value; }
    }
}

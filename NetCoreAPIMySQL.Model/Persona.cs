using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreAPIMySQL.Model
{

    public class Persona
    {
        private long idPersona;
        private string primerNombre;
        private string segundoNombre;
        private string primerApellido;
        private string segundoApellido;
        private long telefono;
        private string direccion;
        private string correo;

        //IdPersona
        [Required(ErrorMessage = "Id Persona es ogligatorio")]
        [Range(0, 9999999999, ErrorMessage = "Id Persona es un Valor fuera de rango")]
        public long IdPersona { get => idPersona; set => idPersona = value; }

        //Primer Nombre
        [Required(ErrorMessage = "Primer nombre es ogligatorio")]
        [StringLength(maximumLength:20,MinimumLength =2,ErrorMessage = "Primer nombre no valido o fuera de rango")]
        public string PrimerNombre { get => primerNombre; set => primerNombre = value; }

        //Segundo Nombre
        [StringLength(maximumLength:20,MinimumLength =2,ErrorMessage = "Segundo nombre no valido o fuera de rango")]
        public string SegundoNombre { get => segundoNombre; set => segundoNombre = value; }

        //Primer Apellido
        [Required(ErrorMessage = "Primer Apellido es ogligatorio")]
        [StringLength(maximumLength:20,MinimumLength =2,ErrorMessage = "Primer apellido no valido o fuera de rango")]

        public string PrimerApellido { get => primerApellido; set => primerApellido = value; }

        //Segundo Apellido
        [Required(ErrorMessage = "Segundo Apellido es ogligatorio")]
        [StringLength(maximumLength:20,MinimumLength =2,ErrorMessage = "Segundo apellido no valido o fuera de rango")]
        public string SegundoApellido { get => segundoApellido; set => segundoApellido = value; }

        //Telefono
        [Required(ErrorMessage = "Telefono es ogligatorio")]
        [Range(1000000, 9999999999, ErrorMessage = "Telefono es un Valor fuera de rango")]
        public long Telefono { get => telefono; set => telefono = value; }

        //Direccion
        [Required(ErrorMessage = "Direccion es ogligatorio")]
        [StringLength(maximumLength:25,MinimumLength =2,ErrorMessage = "Direccion no valida o fuera de rango")]
        public string Direccion { get => direccion; set => direccion = value; }

        //Correo
        [Required(ErrorMessage = "Correo es ogligatorio")]
        [StringLength(maximumLength: 40, MinimumLength = 10, ErrorMessage = "Correo no valido o fuera de rango")]
        public string Correo { get => correo; set => correo = value; }

    }
}

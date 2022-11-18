
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NetCoreAPIMySQL.Model
{
    public class Caso
    {
        private long idCaso;
        private string nombreCaso;
        private string descripcion;
        private long docente;
        private long estudiante;
        private string fecha;
        private string estado;

        //IDCaso
        [Required(ErrorMessage = "Id Caso es ogligatorio")]
        [Range(0,9999999999, ErrorMessage = "Id Caso es un Valor fuera de rango")]
        public long IdCaso { get => idCaso; set => idCaso = value; }

        //Nombre
        [Required(ErrorMessage = "Nombre Caso es ogligatorio")]
        [StringLength(maximumLength: 35, MinimumLength = 2, ErrorMessage = "Nombre de caso no valido o fuera de rango")]
        public string NombreCaso { get => nombreCaso; set => nombreCaso = value; }

        //Descripcion
        [Required(ErrorMessage = "Descripcion Caso es ogligatorio")]
        [StringLength(maximumLength: 300, MinimumLength = 2, ErrorMessage = "Descripcion no valido o fuera de rango")]
        public string Descripcion { get => descripcion; set => descripcion = value; }

        //Docente
        [Required(ErrorMessage = "Docente es ogligatorio")]
        [Range(0,9999999999, ErrorMessage = "Docente es un Valor fuera de rango")]
        public long Docente { get => docente; set => docente = value; }

        //Estudiante
        [Range(0,9999999999, ErrorMessage = "Estudiante es un Valor fuera de rango")]
        public long Estudiante { get => estudiante; set => estudiante = value; }

        //Fecha
        [Required(ErrorMessage = "Fecha es ogligatorio")]
        [StringLength(maximumLength: 10, MinimumLength = 5, ErrorMessage = "Fecha no valido o fuera de rango")]
        public string Fecha { get => fecha; set => fecha = value; }

        //Estado
        [Required(ErrorMessage = "Estado es ogligatorio")]
        [StringLength(maximumLength: 20, MinimumLength = 2, ErrorMessage = "Estado no valido o fuera de rango")]
        public string Estado { get => estado; set => estado = value; }
    }
}
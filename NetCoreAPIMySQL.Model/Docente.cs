using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreAPIMySQL.Model
{
    public class Docente : Persona
    {
        private long idDocente;
        private string facultad;

        //IdDocente
        [Required]
        [Range(0, 9999999999, ErrorMessage = "Valor fuera de rango")]
        public long IdDocente { get => idDocente; set => idDocente = value; }

        //Facultad
        [Required]
        [StringLength(maximumLength: 30, MinimumLength = 2, ErrorMessage = "Faultad no valido o fuera de rango")]
        public string Facultad { get => facultad; set => facultad = value; }

    }
}

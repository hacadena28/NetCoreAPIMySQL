using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreAPIMySQL.Model
{
    public class Administrador : Persona
    {
        private long idAdministrador;

        //IdDocente
        [Required]
        [Range(0, 9999999999, ErrorMessage = "Valor fuera de rango")]
        public long IdAdministrador { get => idAdministrador; set => idAdministrador = value; }

        //Facultad

    }
}

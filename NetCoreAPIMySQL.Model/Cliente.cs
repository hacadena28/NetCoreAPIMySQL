using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreAPIMySQL.Model
{
    public class Cliente : Persona
    {
        private long idCliente;

        //IdCliente
        [Required(ErrorMessage = "Id Cliente es ogligatorio")] 
        [Range(0, 9999999999, ErrorMessage = "Id Cliente es un Valor fuera de rango")]
        public long IdCliente { get => idCliente; set => idCliente = value; }
    }
}

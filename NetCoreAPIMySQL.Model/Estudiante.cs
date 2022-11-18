using System.ComponentModel.DataAnnotations;

namespace NetCoreAPIMySQL.Model
{
    public class Estudiante: Persona{
        private long idEstudiante;
        private long semestre;
        private string estado;

        //Id Estudiante
        [Required(ErrorMessage = "Id Estudiante es ogligatorio")]
        [Range(0, 999999999999999, ErrorMessage = "Id Estudiante es un Valor fuera de rango")]
        public long IdEstudiante { get => idEstudiante; set => idEstudiante = value; }

        //semestre
        [Required(ErrorMessage = "Semestre es ogligatorio")]
        [Range(1,20,ErrorMessage ="Semestre no valido o fuera de rango")]
        public long Semestre { get => semestre; set => semestre = value; }

        //Estado
        [Required(ErrorMessage = "Estado es ogligatorio")]
        [StringLength(10,ErrorMessage ="Estado no valido o fuera de rango")]
        public string Estado { get => estado; set => estado = value; }

    }

}
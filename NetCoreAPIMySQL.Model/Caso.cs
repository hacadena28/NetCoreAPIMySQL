
using System;
using System.Collections.Generic;

namespace NetCoreAPIMySQL.Model
{
    public class Caso{
        private int idCaso;
        private string nombreCaso;
        private string descripcion;
        private int docente;
        private int estudiante;
        private string fecha;

        private string estado;

        public int IdCaso { get => idCaso; set => idCaso = value; }
        public string NombreCaso { get => nombreCaso; set => nombreCaso = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public int Docente { get => docente; set => docente = value; }
        public int Estudiante { get => estudiante; set => estudiante = value; }
        public string Fecha { get => fecha; set => fecha = value; }
        public string Estado { get => estado; set => estado = value; }
    }
}
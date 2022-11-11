
using System;
using System.Collections.Generic;

namespace NetCoreAPIMySQL.Model
{
    public class Caso{
        private int idCaso;
        private string nombreCaso;
        private string descripcion;
        private int idDocente;
        private List<Estudiante> estudiantes;
        private string fecha;

        private string estado;

        public int IdCaso { get => idCaso; set => idCaso = value; }
        public string NombreCaso { get => nombreCaso; set => nombreCaso = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public int IdDocente { get => idDocente; set => idDocente = value; }
        public List<Estudiante> Estudiantes { get => estudiantes; set => estudiantes = value; }
        public string Fecha { get => fecha; set => fecha = value; }
        public string Estado { get => estado; set => estado = value; }
    }
}
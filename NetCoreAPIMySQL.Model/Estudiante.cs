namespace NetCoreAPIMySQL.Model
{
    public class Estudiante{
        private int idEstudiante;
        private string primerNombre;
        private string segundoNombre;
        private string primerApellido;
        private string segundoApellido;
        private int telefono;
        private string direccion;
        private string correo;
        private string semestre;
        private string estado;
        public int IdEstudiante { get => idEstudiante; set => idEstudiante = value; }
        public string PrimerNombre { get => primerNombre; set => primerNombre = value; }
        public string SegundoNombre { get => segundoNombre; set => segundoNombre = value; }
        public string PrimerApellido { get => primerApellido; set => primerApellido = value; }
        public string SegundoApellido { get => segundoApellido; set => segundoApellido = value; }
        public int Telefono { get => telefono; set => telefono = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Correo { get => correo; set => correo = value; }
        public string Semestre { get => semestre; set => semestre = value; }
        public string Estado { get => estado; set => estado = value; }

       
    }

}
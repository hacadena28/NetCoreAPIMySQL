using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetCoreAPIMySQL.Model;

namespace NetCoreAPIMySQL.Data.Repositories
{
    public interface IEstudianteRepository
    {
        Task<IEnumerable<Estudiante>> ConsultarEstudiantes();
        Task<Estudiante> ConsultarEstudiante(long idEstudiante);
        Task<bool> RegistrarEstudiante(Estudiante estudiante);
        Task<bool> ModificarEstudiante(Estudiante estudiante);
        Task<bool> EliminarEstudiante(Estudiante estudiante);

    }
}

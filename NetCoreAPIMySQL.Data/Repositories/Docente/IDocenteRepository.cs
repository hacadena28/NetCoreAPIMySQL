using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetCoreAPIMySQL.Model;

namespace NetCoreAPIMySQL.Data.Repositories
{
    public interface IDocenteRepository
    {
        Task<IEnumerable<Docente>> ConsultarDocentes();
        Task<Docente> ConsultarDocente(long idDocente);
        Task<bool> RegistrarDocente(Docente docente);
        Task<bool> ModificarDocente(Docente docente);
        Task<bool> EliminarDocente(Docente docente);

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetCoreAPIMySQL.Model;

namespace NetCoreAPIMySQL.Data.Repositories
{
    public interface ICasoRepository
    {
        Task<IEnumerable<Caso>> ConsultarCasos();
        Task<Caso> ConsultarCaso(int idCaso);
        Task<bool> RegistrarCaso(Caso caso);
        Task<bool> ModificarCaso(Caso caso);
        Task<bool> EliminarCaso(Caso caso);

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetCoreAPIMySQL.Model;

namespace NetCoreAPIMySQL.Data.Repositories
{
    public interface IAdministradorRepository
    {
        Task<IEnumerable<Administrador>> ConsultarAdministradors();
        Task<Administrador> ConsultarAdministrador(long idAdministrador);
        Task<bool> RegistrarAdministrador(Administrador administrador);
        Task<bool> ModificarAdministrador(Administrador administrador);
        Task<bool> EliminarAdministrador(Administrador administrador);

    }
}

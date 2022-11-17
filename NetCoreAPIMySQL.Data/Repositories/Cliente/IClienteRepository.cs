using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetCoreAPIMySQL.Model;

namespace NetCoreAPIMySQL.Data.Repositories
{
    public interface IClienteRepository
    {
        Task<IEnumerable<Cliente>> ConsultarClientes();
        Task<Cliente> ConsultarCliente(long idCliente);
        Task<bool> RegistrarCliente(Cliente cliente);
        Task<bool> ModificarCliente(Cliente cliente);
        Task<bool> EliminarCliente(Cliente cliente);

    }
}

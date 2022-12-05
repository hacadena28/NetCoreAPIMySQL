using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetCoreAPIMySQL.Model;

namespace NetCoreAPIMySQL.Data.Repositories
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<Usuario>> ConsultarUsuarios();
        Task<Usuario> ConsultarUsuario(string correo);
        Task<Usuario> ConsultarUsuario2(long idUsuario);
        Task<bool> RegistrarUsuario(Usuario usuario);
        Task<bool> ModificarUsuario(Usuario usuario);
        Task<bool> EliminarUsuario(Usuario usuario);

    }
}

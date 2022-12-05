using Dapper;
using MySql.Data.MySqlClient;
using NetCoreAPIMySQL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreAPIMySQL.Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private MySQLConfiguration _connectionString;
        public UsuarioRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }
        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }

        public async Task<IEnumerable<Usuario>> ConsultarUsuarios()
        {
            var db = dbConnection();
            var sql = @"
                        SELECT idUsuario,correo,contrasena,tipoUsuario 
                        FROM Usuario";
            return await db.QueryAsync<Usuario>(sql, new { });

        }



        public async Task<Usuario> ConsultarUsuario(string correo)
        {
            var db = dbConnection();
            var sql = @"
                        SELECT idUsuario,correo,contrasena,tipoUsuario
                        FROM Usuario 
                        WHERE correo = @Correo";
            return await db.QueryFirstOrDefaultAsync<Usuario>(sql, new { Correo = correo });
        }

        public async Task<Usuario> ConsultarUsuario2(long idUsuario)
        {
            var db = dbConnection();
            var sql = @"
                        SELECT idUsuario,correo,contrasena,tipoUsuario
                        FROM Usuario 
                        WHERE idUsuario = @IdUsuario";
            return await db.QueryFirstOrDefaultAsync<Usuario>(sql, new { IdUsuario = idUsuario });
        }



        public async Task<bool> RegistrarUsuario(Usuario usuario)
        {
            var db = dbConnection();
            var sql = @"
                        INSERT INTO Usuario (idUsuario,correo,contrasena,tipoUsuario)
                        VALUE (@IdUsuario,@Correo,@Contrasena,@TipoUsuario)";
            var result = await db.ExecuteAsync(sql, new { usuario.IdUsuario, usuario.Correo, usuario.Contrasena, usuario.TipoUsuario });
            return result > 0;
        }
        public async Task<bool> ModificarUsuario(Usuario usuario)
        {
            var db = dbConnection();
            var sql = @"
                        UPDATE Usuario SET idUsuario = @IdUsuario,correo = @Correo,contrasena = @Contrasena ,tipoUsuario = @TipoUsuario
                        WHERE @IdUsuario = idUsuario";
            var result = await db.ExecuteAsync(sql, new { usuario.IdUsuario, usuario.Correo, usuario.Contrasena, usuario.TipoUsuario });
            return result > 0;
        }
        public async Task<bool> EliminarUsuario(Usuario usuario)
        {
            var db = dbConnection();
            var sql = @"
                        DELETE 
                        FROM Usuario 
                        WHERE idUsuario = @IdUsuario";
            var result = await db.ExecuteAsync(sql, new { IdUsuario = usuario.IdUsuario });
            return result > 0;
        }
    }
}

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
    public class ClienteRepository : IClienteRepository
    {
        private MySQLConfiguration _connectionString;
        public ClienteRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }
        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }
    
        public async Task<IEnumerable<Cliente>> ConsultarClientes()
        {
            var db = dbConnection();
            var sql = @"
                        SELECT idCliente,primerNombre,segundoNombre,primerApellido,segundoApellido,telefono,direccion,correo
                        FROM Cliente";
            return await db.QueryAsync<Cliente>(sql, new { });

        }


        public async Task<Cliente> ConsultarCliente(int idCliente)
        {
            var db = dbConnection();
            var sql = @"
                        SELECT idCliente,primerNombre,segundoNombre,primerApellido,segundoApellido,telefono,direccion,correo
                        FROM Cliente 
                        WHERE idCliente = @IdCliente";
            return await db.QueryFirstOrDefaultAsync<Cliente>(sql, new { IdCliente = idCliente });
        }

        public async Task<bool> RegistrarCliente(Cliente Cliente)
        {
            var db = dbConnection();
            var sql = @"
                        INSERT INTO Cliente (idCliente,primerNombre,segundoNombre,primerApellido,segundoApellido,telefono,direccion,correo)
                        VALUE (@IdCliente,@PrimerNombre,@SegundoNombre,@PrimerApellido,@SegundoApellido,@Telefono,@Direccion,@Correo)";
            var result = await db.ExecuteAsync(sql, new { Cliente.IdCliente, Cliente.PrimerNombre, Cliente.SegundoNombre, Cliente.PrimerApellido, Cliente.SegundoApellido, Cliente.Telefono, Cliente.Direccion, Cliente.Correo });
            return result > 0;
        }
        public async Task<bool> ModificarCliente(Cliente Cliente)
        {
            var db = dbConnection();
            var sql = @"
                        UPDATE Cliente SET idCliente = @IdCliente,primerNombre = @PrimerNombre,segundoNombre = @SegundoNombre ,primerApellido = @PrimerApellido,segundoApellido = @SegundoApellido,telefono = @Telefono,direccion = @Direccion,correo=@Correo
                        WHERE @IdCliente = idCliente";
            var result = await db.ExecuteAsync(sql, new { Cliente.IdCliente, Cliente.PrimerNombre, Cliente.SegundoNombre, Cliente.PrimerApellido, Cliente.SegundoApellido, Cliente.Telefono, Cliente.Direccion, Cliente.Correo });
            return result > 0;
        }
        public async Task<bool> EliminarCliente(Cliente Cliente)
        {
            var db = dbConnection();
            var sql = @"
                        DELETE 
                        FROM Cliente 
                        WHERE idCliente = @IdCliente";
            var result = await db.ExecuteAsync(sql, new { IdCliente = Cliente.IdCliente });
            return result > 0;
        }
    }
}

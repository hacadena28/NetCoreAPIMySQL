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
    public class AdministradorRepository : IAdministradorRepository
    {
        private MySQLConfiguration _connectionString;
        public AdministradorRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }
        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }


        public async Task<IEnumerable<Administrador>> ConsultarAdministradors()
        {
            var db = dbConnection();
            var sql = @"
                        SELECT idAdministrador,primerNombre,segundoNombre,primerApellido,segundoApellido,telefono,direccion,correo
                        FROM Administrador";
            return await db.QueryAsync<Administrador>(sql, new { });

        }



        public async Task<Administrador> ConsultarAdministrador(long idAdministrador)
        {

            if (idAdministrador != 0)
            {
                if(idAdministrador > 0 && idAdministrador <10000000000 )
                {
                    var db = dbConnection();
                    var sql = @"
                        SELECT idAdministrador,primerNombre,segundoNombre,primerApellido,segundoApellido,telefono,direccion,correo
                        FROM Administrador 
                        WHERE idAdministrador = @IdAdministrador";
                    return await db.QueryFirstOrDefaultAsync<Administrador>(sql, new { IdAdministrador = idAdministrador });
                } else { return null; }
            }
            else { return null; }
           
        }

        public async Task<bool> RegistrarAdministrador(Administrador administrador)
        {
            var result = 0;
            if (administrador.PrimerApellido =="") {

                return false;
            };
            var db = dbConnection();
            var sql = @"
                        INSERT INTO Administrador (idAdministrador,primerNombre,segundoNombre,primerApellido,segundoApellido,telefono,direccion,correo)
                        VALUE (@IdAdministrador,@PrimerNombre,@SegundoNombre,@PrimerApellido,@SegundoApellido,@Telefono,@Direccion,@Correo)";
            result = await db.ExecuteAsync(sql, new { administrador.IdAdministrador, administrador.PrimerNombre, administrador.SegundoNombre, administrador.PrimerApellido, administrador.SegundoApellido, administrador.Telefono, administrador.Direccion, administrador.Correo});
            return result > 0;
        }
        public async Task<bool> ModificarAdministrador(Administrador administrador)
        {
            var db = dbConnection();
            var sql = @"
                        UPDATE Administrador SET idAdministrador = @IdAdministrador,primerNombre = @PrimerNombre,segundoNombre = @SegundoNombre ,primerApellido = @PrimerApellido,segundoApellido = @SegundoApellido,telefono = @Telefono,direccion = @Direccion,correo=@Correo
                        WHERE @IdAdministrador = idAdministrador";
            var result = await db.ExecuteAsync(sql, new { administrador.IdAdministrador, administrador.PrimerNombre, administrador.SegundoNombre, administrador.PrimerApellido, administrador.SegundoApellido, administrador.Telefono, administrador.Direccion, administrador.Correo });
            return result > 0;
        }
        public async Task<bool> EliminarAdministrador(Administrador administrador)
        {
            var db = dbConnection();
            var sql = @"
                        DELETE 
                        FROM Administrador 
                        WHERE idAdministrador = @IdAdministrador";
            var result = await db.ExecuteAsync(sql, new { IdAdministrador = administrador.IdAdministrador });
            return result > 0;
        }
    }
}

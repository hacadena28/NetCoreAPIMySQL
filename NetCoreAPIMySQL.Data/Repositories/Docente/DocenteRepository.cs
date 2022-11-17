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
    public class DocenteRepository : IDocenteRepository
    {
        private MySQLConfiguration _connectionString;
        public DocenteRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }
        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }


        public async Task<IEnumerable<Docente>> ConsultarDocentes()
        {
            var db = dbConnection();
            var sql = @"
                        SELECT idDocente,primerNombre,segundoNombre,primerApellido,segundoApellido,telefono,direccion,correo,facultad
                        FROM Docente";
            return await db.QueryAsync<Docente>(sql, new { });

        }



        public async Task<Docente> ConsultarDocente(long idDocente)
        {
            var db = dbConnection();
            var sql = @"
                        SELECT idDocente,primerNombre,segundoNombre,primerApellido,segundoApellido,telefono,direccion,correo,facultad
                        FROM Docente 
                        WHERE idDocente = @IdDocente";
            return await db.QueryFirstOrDefaultAsync<Docente>(sql, new { IdDocente = idDocente });
        }

        public async Task<bool> RegistrarDocente(Docente docente)
        {
            var db = dbConnection();
            var sql = @"
                        INSERT INTO Docente (idDocente,primerNombre,segundoNombre,primerApellido,segundoApellido,telefono,direccion,correo,facultad)
                        VALUE (@IdDocente,@PrimerNombre,@SegundoNombre,@PrimerApellido,@SegundoApellido,@Telefono,@Direccion,@Correo,@Facultad)";
            var result = await db.ExecuteAsync(sql, new { docente.IdDocente, docente.PrimerNombre, docente.SegundoNombre, docente.PrimerApellido, docente.SegundoApellido, docente.Telefono, docente.Direccion, docente.Correo,docente.Facultad});
            return result > 0;
        }
        public async Task<bool> ModificarDocente(Docente docente)
        {
            var db = dbConnection();
            var sql = @"
                        UPDATE Docente SET idDocente = @IdDocente,primerNombre = @PrimerNombre,segundoNombre = @SegundoNombre ,primerApellido = @PrimerApellido,segundoApellido = @SegundoApellido,telefono = @Telefono,direccion = @Direccion,correo=@Correo
                        WHERE @IdDocente = idDocente";
            var result = await db.ExecuteAsync(sql, new { docente.IdDocente, docente.PrimerNombre, docente.SegundoNombre, docente.PrimerApellido, docente.SegundoApellido, docente.Telefono, docente.Direccion, docente.Correo, docente.Facultad });
            return result > 0;
        }
        public async Task<bool> EliminarDocente(Docente docente)
        {
            var db = dbConnection();
            var sql = @"
                        DELETE 
                        FROM Docente 
                        WHERE idDocente = @IdDocente";
            var result = await db.ExecuteAsync(sql, new { IdDocente = docente.IdDocente });
            return result > 0;
        }
    }
}

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
    public class CasoRepository : ICasoRepository
    {
        private MySQLConfiguration _connectionString;
        public CasoRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }
        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }
    
        public async Task<IEnumerable<Caso>> ConsultarCasos()
        {
            var db = dbConnection();
            var sql = @"
                        SELECT idCaso,nombreCaso,descripcion,docente,estudiante,cliente,fecha,estado
                        FROM Caso";
            return await db.QueryAsync<Caso>(sql, new { });

        }


        public async Task<Caso> ConsultarCaso(long idCaso)
        {
            var db = dbConnection();
            var sql = @"
                        SELECT idCaso,nombreCaso,descripcion,docente,estudiante,cliente,fecha,estado
                        FROM Caso 
                        WHERE idCaso = @IdCaso";
            return await db.QueryFirstOrDefaultAsync<Caso>(sql, new { IdCaso = idCaso });
        }

        public async Task<bool> RegistrarCaso(Caso caso)
        {
            var db = dbConnection();
            var sql = @"
                        INSERT INTO Caso (idCaso,nombreCaso,descripcion,docente,estudiante,cliente,fecha,estado)
                        VALUE (@IdCaso,@NombreCaso,@Descripcion,@Docente,@Estudiante,@Cliente,@Fecha,@Estado)";
            var result = await db.ExecuteAsync(sql, new { caso.IdCaso, caso.NombreCaso, caso.Descripcion, caso.Docente, caso.Estudiante,caso.Cliente, caso.Fecha, caso.Estado });
            return result > 0;
        }
        public async Task<bool> ModificarCaso(Caso caso)
        {
            var db = dbConnection();
            var sql = @"
                        UPDATE Caso SET idCaso = @IdCaso,nombreCaso = @NombreCaso,descripcion = @Descripcion ,docente = @Docente,estudiante = @Estudiante,cliente = @Cliente,fecha = @Fecha,estado = @Estado
                        WHERE @IdCaso = idCaso";
            var result = await db.ExecuteAsync(sql, new {caso.IdCaso, caso.NombreCaso, caso.Descripcion, caso.Docente, caso.Estudiante, caso.Cliente, caso.Fecha, caso.Estado});
            return result > 0;
        }
        public async Task<bool> EliminarCaso(Caso caso)
        {
            var db = dbConnection();
            var sql = @"
                        DELETE 
                        FROM Caso 
                        WHERE idCaso = @IdCaso";
            var result = await db.ExecuteAsync(sql, new { IdCaso = caso.IdCaso });
            return result > 0;
        }
    }
}

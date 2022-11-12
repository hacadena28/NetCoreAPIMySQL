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
    public class EstudianteRepository : IEstudianteRepository
    {
        private MySQLConfiguration _connectionString;
        public EstudianteRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }
        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }


        public async Task<IEnumerable<Estudiante>> ConsultarEstudiantes()
        {
            var db = dbConnection();
            var sql = @"
                        SELECT idEstudiante,primerNombre,segundoNombre,primerApellido,segundoApellido,telefono,direccion,correo,semestre,estado
                        FROM Estudiante";
            return await db.QueryAsync<Estudiante>(sql, new { });

        }



        public async Task<Estudiante> ConsultarEstudiante(int idEstudiante)
        {
            var db = dbConnection();
            var sql = @"
                        SELECT idEstudiante,primerNombre,segundoNombre,primerApellido,segundoApellido,telefono,direccion,correo,semestre,estado
                        FROM Estudiante 
                        WHERE idEstudiante = @IdEstudiante";
            return await db.QueryFirstOrDefaultAsync<Estudiante>(sql, new { IdEstudiante = idEstudiante });
        }

        public async Task<bool> RegistrarEstudiante(Estudiante estudiante)
        {
            var db = dbConnection();
            var sql = @"
                        INSERT INTO Estudiante (idEstudiante,primerNombre,segundoNombre,primerApellido,segundoApellido,telefono,direccion,correo,semestre,estado)
                        VALUE (@IdEstudiante,@PrimerNombre,@SegundoNombre,@PrimerApellido,@SegundoApellido,@Telefono,@Direccion,@Correo,@Semestre,@Estado)";
            var result = await db.ExecuteAsync(sql, new { estudiante.IdEstudiante, estudiante.PrimerNombre, estudiante.SegundoNombre, estudiante.PrimerApellido, estudiante.SegundoApellido, estudiante.Telefono, estudiante.Direccion, estudiante.Correo,estudiante.Semestre,estudiante.Estado });
            return result > 0;
        }
        public async Task<bool> ModificarEstudiante(Estudiante estudiante)
        {
            var db = dbConnection();
            var sql = @"
                        UPDATE Estudiante SET idEstudiante = @IdEstudiante,primerNombre = @PrimerNombre,segundoNombre = @SegundoNombre ,primerApellido = @PrimerApellido,segundoApellido = @SegundoApellido,telefono = @Telefono,direccion = @Direccion,correo=@Correo,semestre=@Semestre,estado=@Estado
                        WHERE @IdEstudiante = idEstudiante";
            var result = await db.ExecuteAsync(sql, new { estudiante.IdEstudiante, estudiante.PrimerNombre, estudiante.SegundoNombre, estudiante.PrimerApellido, estudiante.SegundoApellido, estudiante.Telefono, estudiante.Direccion, estudiante.Correo, estudiante.Semestre, estudiante.Estado });
            return result > 0;
        }
        public async Task<bool> EliminarEstudiante(Estudiante estudiante)
        {
            var db = dbConnection();
            var sql = @"
                        DELETE 
                        FROM Estudiante 
                        WHERE idEstudiante = @IdEstudiante";
            var result = await db.ExecuteAsync(sql, new { IdEstudiante = estudiante.IdEstudiante });
            return result > 0;
        }


    }
}

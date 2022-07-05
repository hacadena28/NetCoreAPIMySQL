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
    public class PersonaRepository : IPersonaRepository
    {
        private MySQLConfiguration _connectionString;
        public PersonaRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }
        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }
       

        public async Task<IEnumerable<Persona>> GetAllPersona()
        {
            var db = dbConnection();
            var sql = @"
                        SELECT idPersona,nombres,apellidos,edad,celular,correo 
                        FROM Persona";
            return await db.QueryAsync<Persona>(sql, new { });

        }

        public async Task<Persona> GetPersonaDetails(int idPersona)
        {
            var db = dbConnection();
            var sql = @"
                        SELECT idPersona,nombres,apellidos,edad,celular,correo 
                        FROM Persona 
                        WHERE idPersona = @IdPersona";
            return await db.QueryFirstOrDefaultAsync<Persona>(sql, new { IdPersona = idPersona });
        }

        public async Task<bool> InsertPersona(Persona persona)
        {
            var db = dbConnection();
            var sql = @"
                        INSERT INTO Persona (idPersona,nombres,apellidos,edad,celular,correo)
                        VALUE (@IdPersona,@Nombres,@Apellidos,@Edad,@Celular,@Correo)";
            var result = await db.ExecuteAsync(sql, new { persona.IdPersona, persona.Nombres, persona.Apellidos, persona.Edad, persona.Celular, persona.Correo });
            return result > 0;
        }

        public async Task<bool> UpdatePersona(Persona persona)
        {
            var db = dbConnection();
            var sql = @"
                        UPDATE Persona SET idPersona = @IdPersona,nombres = @Nombres,apellidos = @Apellidos ,edad = @Edad,celular = @Celular,correo = @Correo
                        WHERE @IdPersona = idPersona";
            var result = await db.ExecuteAsync(sql, new { persona.IdPersona,persona.Nombres, persona.Apellidos, persona.Edad, persona.Celular, persona.Correo });
            return result > 0;
        }

        public async Task<bool> DeletePersona(Persona persona)
        {
            var db = dbConnection();
            var sql = @"
                        DELETE 
                        FROM Persona 
                        WHERE idPersona = @IdPersona";
            var result = await db.ExecuteAsync(sql, new { IdPersona = persona.IdPersona });
            return result > 0;
        }
    }
}

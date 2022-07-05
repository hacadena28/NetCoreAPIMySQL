using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetCoreAPIMySQL.Model;

namespace NetCoreAPIMySQL.Data.Repositories
{
    public interface IPersonaRepository
    {
        Task<IEnumerable<Persona>> GetAllPersona();
        Task<Persona> GetPersonaDetails(int idPersona);
        Task<bool> InsertPersona(Persona persona);
        Task<bool> UpdatePersona(Persona persona);
        Task<bool> DeletePersona(Persona persona);

    }
}

using Foco.API.Entities;
using Foco.API.Repositories.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Foco.API.Repositories.Interfaces
{
    public interface IPersonRepository: IRepository<Person>
    {
        Task<IEnumerable<Person>> GetAllPersonInSite(int siteId);
        Task<Person> GetPersonByTz(string tz);
        Task<Person> GetNextInLine(int siteId);
    }
}

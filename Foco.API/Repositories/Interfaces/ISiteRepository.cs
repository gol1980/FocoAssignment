using Foco.API.Entities;
using Foco.API.Repositories.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Foco.API.Repositories.Interfaces
{
    public interface ISiteRepository : IRepository<Site>
    {
        Task<IEnumerable<Person>> GetSitePersons(int siteId);
        Task AddPersonToSite(Person person);
    }
}

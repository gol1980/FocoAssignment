using Foco.API.Entities;
using Foco.API.Persistence;
using Foco.API.Repositories.Base;
using Foco.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foco.API.Repositories
{
    public class SiteRepository : RepositoryBase<Site>, ISiteRepository
    {
        public SiteRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {
        }

        public async Task<IEnumerable<Person>> GetSitePersons(int siteId)
        {
            return await _dbContext.Persons.Where(p => p.Id == siteId).ToListAsync();
        }

        public async Task AddPersonToSite(Person person)
        {
            await _dbContext.Persons.AddAsync(person);
            await _dbContext.SaveChangesAsync();
        }
    }
}

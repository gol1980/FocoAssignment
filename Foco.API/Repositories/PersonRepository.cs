using Foco.API.Entities;
using Foco.API.Enums;
using Foco.API.Persistence;
using Foco.API.Repositories.Base;
using Foco.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foco.API.Repositories
{
    public class PersonRepository : RepositoryBase<Person>, IPersonRepository
    {
        public PersonRepository(ApplicationDbContext dbContext)
           : base(dbContext)
        {
        }

        public async Task<IEnumerable<Person>> GetAllPersonInSite(int siteId)
        {
            return await _dbContext.Persons.Where(p => p.SiteId == siteId).ToListAsync();
        }

        public async Task<Person> GetPersonByTz(string tz)
        {
            return await _dbContext.Persons.FirstOrDefaultAsync(p => p.Tz == tz);
        }

        public async Task<Person> GetNextInLine(int siteId)
        {
            return await _dbContext.Persons.Where(p => p.SiteId == siteId && p.PatientStatus == PatientStatus.IsAwaiting)
                .OrderBy(p => p.QueueNumber).FirstOrDefaultAsync();
        }
    }
}

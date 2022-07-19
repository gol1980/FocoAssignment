using Foco.API.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Foco.API.BLs.Interfaces
{
    public interface ISiteBL
    {
        Task<int> AddToQueueAsync(Person person, int siteId);
        Task<IEnumerable<Person>> GetQueueAsync(int siteId);
        Task<Person> CallNext(int siteId);
    }
}

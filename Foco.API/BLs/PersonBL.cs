using Foco.API.BLs.Interfaces;
using Foco.API.Repositories.Interfaces;

namespace Foco.API.BLs
{
    public class PersonBL: IPersonBL
    {
        private readonly IPersonRepository _personRepository;

        public PersonBL(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }
    }
}

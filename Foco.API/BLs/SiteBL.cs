using Foco.API.BLs.Interfaces;
using Foco.API.Entities;
using Foco.API.Enums;
using Foco.API.Exceptions;
using Foco.API.Repositories.Interfaces;
using Foco.API.Services.SendService.Interfaces;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Foco.API.BLs
{
    public class SiteBL : ISiteBL
    {
        private readonly ISiteRepository _siteRepository;
        private readonly IPersonRepository _personRepository;
        private readonly ISmsService _smsService;
        public ILogger<SiteBL> _logger { get; set; }

        public SiteBL(ISiteRepository siteRepository,
            IPersonRepository personRepository,
            ISmsService smsService, 
            ILogger<SiteBL> logger)
        {
            _siteRepository = siteRepository;
            _personRepository = personRepository;
            _smsService = smsService;
            _logger = logger;
        }

        public async Task<int> AddToQueueAsync(Person person, int siteId)
        {
            var site = await _siteRepository.GetByIdAsync(siteId);
            if (site == null)
            {
                throw new AppException("Site not exist", HttpStatusCode.NoContent);
            }

            //check if exist
            var existPerson = await _personRepository.GetPersonByTz(person.Tz);
            if (existPerson != null)
            {
                throw new AppException("Person Exist in Queue", HttpStatusCode.BadRequest);
            }

            person.SiteId = siteId;
            var queueNumber = _personRepository.GetAsync(p => p.SiteId == siteId).Result.Count + 1;
            person.QueueNumber = queueNumber;
            person.PatientStatus = PatientStatus.IsAwaiting;

            await _siteRepository.AddPersonToSite(person);

            //send sms
            if(!(_smsService.SendAsync(person.PhoneNumber, person.QueueNumber).Result))
            {
                _logger.LogError($"Faild to send text to person{JsonConvert.SerializeObject(person)}");
            }

            return queueNumber;
        }
            
        public async Task<IEnumerable<Person>> GetQueueAsync(int siteId)
        {
            return await _personRepository.GetAllPersonInSite(siteId);
        }

        public async Task<Person> CallNext(int siteId)
        {
            var person = await _personRepository.GetNextInLine(siteId);
            if (person == null)
            {
                throw new AppException("Queue in Empty", HttpStatusCode.NoContent);
            }

            person.PatientStatus = PatientStatus.OnProgress;
            await _personRepository.UpdateAsync(person);
            return person;
        }

        
    }
}

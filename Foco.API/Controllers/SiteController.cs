using Foco.API.BLs.Interfaces;
using Foco.API.Controllers.Base;
using Foco.API.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Foco.API.Controllers
{
    [Route("api/sites")]
    public class SiteController : BaseController<SiteController>
    {

        private readonly ISiteBL _siteBL;

        public SiteController(ISiteBL siteBL)
        {
            _siteBL = siteBL;
        }

        [HttpGet("{siteId}")]
        public async Task<ActionResult<List<Person>>> GetQueueAsync(int siteId)
        {
            var persons = await _siteBL.GetQueueAsync(siteId);
            return Ok(persons);
        }

        [HttpPost("{siteId}/customers")]
        public async Task<IActionResult> AddToQueueAsync(Person person, int siteId)
        {
            var ticketNum = await _siteBL.AddToQueueAsync(person, siteId);
            return Ok(ticketNum);
        }


        [HttpPost("{siteId}/actions/callNext")]
        public async Task<ActionResult<Person>> CallNextAsync(int siteId)
        {
            var person = await _siteBL.CallNext(siteId);
            return Ok(person);
        }
    }
}

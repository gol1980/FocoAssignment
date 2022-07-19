using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Foco.API.Controllers.Base
{
    
    [ApiController]
    public class BaseController<T> : ControllerBase where T : BaseController<T>
    {
        private ILogger<T> _logger;
        protected ILogger<T> logger => _logger ?? (_logger = HttpContext.RequestServices.GetService<ILogger<T>>());
    }
}

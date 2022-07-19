using Foco.API.Services.SendService.Interfaces;
using System.Threading.Tasks;

namespace Foco.API.Services.SendService
{
    public class SmsService : ISmsService
    {
        public async Task<bool> SendAsync(string phoneNumber, int QueueNumber)
        {
            //Send an sms
            return await Task.FromResult(true);
        }
    }
}

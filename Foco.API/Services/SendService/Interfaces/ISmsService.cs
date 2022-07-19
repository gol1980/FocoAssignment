using System.Threading.Tasks;

namespace Foco.API.Services.SendService.Interfaces
{
    public interface ISmsService
    {
        Task<bool> SendAsync(string phoneNumber, int QueueNumber);
    }
}

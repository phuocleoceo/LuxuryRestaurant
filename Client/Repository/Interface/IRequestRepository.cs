using Common.DTO;
using System.Threading.Tasks;

namespace Client.Repository.Interface
{
    public interface IRequestRepository
    {
        Task<bool> SendRequest(UserRequest ur);
    }
}

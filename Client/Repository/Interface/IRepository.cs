using System.Threading.Tasks;

namespace Client.Repository.Interface
{
    public interface IRepository
    {
        Task<string> SendAndReceiveAsync(string Header, string Body);
    }
}

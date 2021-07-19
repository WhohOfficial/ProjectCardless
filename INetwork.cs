using System.Threading.Tasks;

namespace ProjectCardless
{
    interface INetwork
    {
        Task<bool> RegisterAsync(User user);
        Task<bool> LoginAsync(User user);
    }
}
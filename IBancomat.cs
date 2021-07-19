using System.Threading.Tasks;

namespace ProjectCardless
{
    interface IBancomat
    {
        Task<float> Withdraw(float value, User user);
        Task<float> Deposit(float value, User user);
    }
}

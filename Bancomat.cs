using System.Threading.Tasks;

namespace ProjectCardless
{
    class Bancomat : IBancomat
    {
        public async Task<float> Deposit(float value, User user)
        {
            if (user.Balance > value)
                return user.Balance - value;

            return user.Balance;
        }

        public Task<bool> Withdraw(float value, User user)
        {
            throw new System.NotImplementedException();
        }
    }
}

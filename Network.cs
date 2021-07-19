using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace ProjectCardless
{
    class Network : INetwork
    {
        public async Task<bool> LoginAsync(User user)
        {
            if (!File.Exists($"{user.Id}"))
                return false;

            var savedUser = await JsonSerializer.DeserializeAsync<User>(
                File.Open($"{user.Id}", FileMode.Open));

            if (user.Password == savedUser.Password)
                return true;

            return false;
        }

        public async Task<bool> RegisterAsync(User user)
        {
            if (File.Exists($"{user.Id}"))
                return false;

            using (var createStream = File.Create($"{user.Id}")) {
                await JsonSerializer.SerializeAsync(createStream, user);
                await createStream.DisposeAsync();
            }

            return true;
        }
    }
}

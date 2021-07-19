using ProjectCardless.Utils;

namespace ProjectCardless
{
    unsafe class User
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Password { get; set; }
        public float Balance { get; set; }
        public long Id { get; set; }
        public User(string firstName, string secondName, string password)
        {
            FirstName = firstName;
            SecondName = secondName;
            Password = password;
        }

        public static User GetUser() {
            return new User(
                    ConsoleLog.Input("First Name: ", inlineWrite: true),
                    ConsoleLog.Input("Second Name: ", inlineWrite: true),
                    ConsoleLog.Input("Password: ", inlineWrite: true)
                );
        }
    }
}

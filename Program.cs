using ProjectCardless.Enums;
using ProjectCardless.Utils;
using System;
using System.Threading.Tasks;

namespace ProjectCardless
{
    class Program
    {
        static async Task Main()
        {
            var network = new Network();

        Auth:
            var firstPick = ConsoleLog.Input("1. Login\n2. Register");
            var authStatus = await ((firstPick) switch {
                "1" => network.LoginAsync(User.GetUser()),
                "2" => network.RegisterAsync(User.GetUser()),
                _ => ConsoleLog.Output("Invalid menu option", StateType.Error)
            });

            if (authStatus)
                if (firstPick is "1")
                    goto Auth;


            var bancomat = new Bancomat();

        Action:
            var actionStatus = await (ConsoleLog.Input("1. Withdraw\n2. Deposit") switch
            {
                "1" => bancomat.Withdraw(
                    await SafeParse.FloatAsync(
                            ConsoleLog.Input("Withdrawal Amount: ", inlineWrite: true)
                        )
                    ),
                "2" => bancomat.Deposit(
                    await SafeParse.FloatAsync(
                            ConsoleLog.Input("Deposit Amount: ", inlineWrite: true)
                        )
                    ),
                _ => ConsoleLog.Output("Invalid menu option", StateType.Error)
            });

            if (actionStatus)
                await ConsoleLog.Output("Workflow finished", StateType.Info);

            await ConsoleLog.Output("Press 'Esc' to exit, any other key to continue.", StateType.Info);
            if (Console.ReadKey().Key != ConsoleKey.Escape)
                goto Action;

            Console.ReadLine();
            Environment.Exit(0);
        }
    }
}

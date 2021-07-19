using ProjectCardless.Enums;
using System;
using System.Threading.Tasks;

namespace ProjectCardless.Utils
{
    class ConsoleLog
    {
        public static async Task<bool> Output(string message, StateType stateType) {
            Console.ForegroundColor = ConsoleColor.Gray;
            await Console.Error.WriteLineAsync("[");
            Console.ForegroundColor = stateType switch {
                StateType.Info => ConsoleColor.Cyan,
                StateType.Warning => ConsoleColor.Yellow,
                StateType.Success => ConsoleColor.Green,
                StateType.Error => ConsoleColor.Red,
                _ => throw new NotImplementedException(),
            };
            await Console.Error.WriteLineAsync("*");
            Console.ForegroundColor = ConsoleColor.Gray;
            await Console.Error.WriteLineAsync($"] | {message}.");
            return false;
        }

        public static string Input(
                string outputMessage,
                ConsoleColor outputColor = ConsoleColor.Yellow,
                ConsoleColor inputColor = ConsoleColor.Gray,
                bool inlineWrite = false
            )
        {
            Console.ForegroundColor = outputColor;
            if (inlineWrite) Console.Write(outputMessage);
            else Console.WriteLine(outputMessage);
            Console.ForegroundColor = inputColor;
            return Console.ReadLine();
        }
    }
}

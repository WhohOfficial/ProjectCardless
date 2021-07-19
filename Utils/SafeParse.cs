using ProjectCardless.Enums;
using System.Threading.Tasks;

namespace ProjectCardless.Utils
{
    class SafeParse
    {
        public static async Task<float> FloatAsync(string value) {
            var k = float.NaN;
            if(!float.TryParse(value, out k)) {
                await ConsoleLog.Output("Invalid float input", StateType.Error);
                return k;
            }

            return k;
        }
    }
}

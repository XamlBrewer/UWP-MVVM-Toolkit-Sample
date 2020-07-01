using System.Diagnostics;
using System.Threading.Tasks;

namespace XamlBrewer.UWP.MvvmToolkit.Sample.Services.Logging
{
    public class DebugLoggingService : ILoggingService
    {
        public Task Log(string message)
        {
            Debug.WriteLine(message);
            return Task.FromResult(0);
        }
    }
}

using System.Threading.Tasks;

namespace XamlBrewer.UWP.MvvmToolkit.Sample.Services.Logging
{
    public interface ILoggingService
    {
        Task Log(string message);
    }
}

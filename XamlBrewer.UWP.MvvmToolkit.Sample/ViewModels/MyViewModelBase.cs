using Microsoft.Extensions.DependencyInjection;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using XamlBrewer.UWP.MvvmToolkit.Sample.Services.Logging;

namespace XamlBrewer.UWP.MvvmToolkit.Sample.ViewModels
{
    public class MyViewModelBase : ObservableRecipient
    {
        public ILoggingService LoggingService => App.ServiceProvider.GetService<ILoggingService>();
    }
}

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using XamlBrewer.UWP.MvvmToolkit.Sample.Services.Logging;

namespace XamlBrewer.UWP.MvvmToolkit.Sample.ViewModels
{
    public class MyViewModelBase : ObservableRecipient
    {
        public ILoggingService LoggingService => Ioc.Default.GetService<ILoggingService>();
    }
}

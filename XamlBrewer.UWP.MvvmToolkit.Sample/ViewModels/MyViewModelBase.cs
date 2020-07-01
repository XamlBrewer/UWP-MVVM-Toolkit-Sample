using Microsoft.Extensions.DependencyInjection;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using XamlBrewer.UWP.MvvmToolkit.Sample.Services.Logging;

namespace XamlBrewer.UWP.MvvmToolkit.Sample.ViewModels
{
    public class MyViewModelBase : ViewModelBase
    {
        private bool _isBusy = false;

        public bool IsBusy
        {
            get => _isBusy;
            set => Set(ref _isBusy, value);
        }

        public ILoggingService LoggingService => Ioc.Default.GetService<ILoggingService>();
    }
}

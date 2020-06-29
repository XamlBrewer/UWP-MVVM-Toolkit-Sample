using Microsoft.Toolkit.Mvvm.ComponentModel;

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
    }
}

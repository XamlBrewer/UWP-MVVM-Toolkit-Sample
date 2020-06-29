using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System.Threading.Tasks;
using System.Windows.Input;
using XamlBrewer.UWP.MvvmToolkit.Sample.Models;
using XamlBrewer.UWP.MvvmToolkit.Sample.Services;

namespace XamlBrewer.UWP.MvvmToolkit.Sample.ViewModels
{
    public class FirstPageViewModel : MyViewModelBase
    {
        private SuperHero _superHero;
        private IDataProvider _dataProvider;

        public FirstPageViewModel()
        {
            _dataProvider = new RedDataProvider();
            _superHero = _dataProvider.SuperHero();
            SwitchDataProviderCommand = new RelayCommand(SwitchDataProvider);
            SwitchDataProviderAsyncCommand = new AsyncRelayCommand(SwitchDataProviderAsync);
        }

        public IDataProvider DataProvider
        {
            get => _dataProvider;
            set => Set(ref _dataProvider, value);
        }

        public SuperHero SuperHero
        {
            get => _superHero;
            set => Set(ref _superHero, value);
        }

        public ICommand SwitchDataProviderCommand { get; }
        public IAsyncRelayCommand SwitchDataProviderAsyncCommand { get; }

        private void SwitchDataProvider()
        {
            if (_dataProvider is RedDataProvider)
            {
                DataProvider = new BlueDataProvider();
            }
            else
            {
                DataProvider = new RedDataProvider();
            }

            // SuperHero = _dataProvider.SuperHero();

            // or

            // _superHero = _dataProvider.SuperHero();
            // OnPropertyChanged(nameof(SuperHero));

            // or

            _superHero = _dataProvider.SuperHero();
            OnPropertyChanged(null);

            // but not

            // _superHero = _dataProvider.SuperHero();
            // OnPropertyChanged();
        }

        private async Task SwitchDataProviderAsync()
        {
            IsBusy = true;

            await Task.Delay(1000);

            if (_dataProvider is RedDataProvider)
            {
                DataProvider = new BlueDataProvider();
            }
            else
            {
                DataProvider = new RedDataProvider();
            }

            _superHero = _dataProvider.SuperHero();
            OnPropertyChanged(null);

            IsBusy = false;
        }
    }
}

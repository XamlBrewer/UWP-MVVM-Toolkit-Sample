using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.ApplicationModel.Core;
using Windows.UI.Core;
using XamlBrewer.UWP.MvvmToolkit.Sample.Models;
using XamlBrewer.UWP.MvvmToolkit.Sample.Services;

namespace XamlBrewer.UWP.MvvmToolkit.Sample.ViewModels
{
    public class BuildingBlocksPageViewModel : MyViewModelBase
    {
        private SuperHero _superHero;
        private IDataProvider _dataProvider;
        private TaskNotifier<string> _saveTheUniverseTask;
        private Random rnd = new Random();
        private StudyGroup _studyGroup = new StudyGroup();

        public BuildingBlocksPageViewModel()
        {
            _dataProvider = new RedDataProvider();
            _superHero = _dataProvider.SuperHero();
            SwitchDataProviderCommand = new RelayCommand(SwitchDataProvider);
            SwitchDataProviderAsyncCommand = new AsyncRelayCommand(
                SwitchDataProviderAsync, 
                () => _dataProvider is RedDataProvider);

            this.PropertyChanged += BuildingBlocksPageViewModel_PropertyChanged;
            // _studyGroup.ErrorsChanged += _studyGroup_ErrorsChanged;
        }

        //private void _studyGroup_ErrorsChanged(object sender, System.ComponentModel.DataErrorsChangedEventArgs e)
        //{
        //    var errors = _studyGroup.GetErrors(null);
        //}

        private void BuildingBlocksPageViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(SaveTheUniverseTask))
            {
                OnPropertyChanged(nameof(SaveTheUniverseTaskResult));
            }
        }

        public IDataProvider DataProvider
        {
            get => _dataProvider;
            set => SetProperty(ref _dataProvider, value);
        }

        public SuperHero SuperHero
        {
            get => _superHero;
            set => SetProperty(ref _superHero, value);
        }

        public ICommand SwitchDataProviderCommand { get; }

        public IAsyncRelayCommand SwitchDataProviderAsyncCommand { get; }

        public Task<string> SaveTheUniverseTask
        {
            get => _saveTheUniverseTask;
            private set
            {
                SetPropertyAndNotifyOnCompletion(ref _saveTheUniverseTask, value);
            }
        }

        public string SaveTheUniverseTaskResult => SaveTheUniverseTask == null ? "?" : SaveTheUniverseTask.Status == TaskStatus.RanToCompletion ? SaveTheUniverseTask.Result : "(hold your breath)";

        public StudyGroup StudyGroup => _studyGroup;

        public async Task SaveTheUniverse()
        {
            SaveTheUniverseTask = new Task<string>(
                () =>
                {
                    // Time travellers can save the world in a few seconds.
                    Task.Delay(2000).Wait();

                    // Don't try this at home or anywhere else:
                    // OnPropertyChanged(nameof(SaveTheUniverseTask));

                    var dispatcher = CoreApplication.MainView.CoreWindow.Dispatcher;
                    _ = dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                      {
                          // Just for Example (to see more than 'Created' and 'Completed')
                          OnPropertyChanged(nameof(SaveTheUniverseTask));
                      });

                    Task.Delay(2000).Wait();

                    if (rnd.Next(2) > 0)
                    {
                        return $"We're doomed, I lost my {SuperHero.Tool}.";
                    }

                    return "We're saved ... this time.";
                }
            );

            await Task.Delay(2000); // To see the Created state before starting.
            SaveTheUniverseTask.Start();
            OnPropertyChanged(nameof(SaveTheUniverseTask)); // Just for Example (to see more than 'Created' and 'Completed')
        }

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

            SuperHero = _dataProvider.SuperHero();

            // or

            // _superHero = _dataProvider.SuperHero();
            // OnPropertyChanged(nameof(SuperHero));

            // or

            // _superHero = _dataProvider.SuperHero();
            // OnPropertyChanged(null);

            // but not

            // _superHero = _dataProvider.SuperHero();
            // OnPropertyChanged();

            SwitchDataProviderAsyncCommand.NotifyCanExecuteChanged();
        }

        private async Task SwitchDataProviderAsync()
        {
            await Task.Delay(1000);

            SwitchDataProvider();
        }
    }
}

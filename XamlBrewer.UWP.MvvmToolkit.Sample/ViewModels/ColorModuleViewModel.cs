using Microsoft.Toolkit.Mvvm.Messaging;
using System.Threading.Tasks;
using Windows.UI;
using XamlBrewer.UWP.MvvmToolkit.Sample.Models;
using XamlBrewer.UWP.MvvmToolkit.Sample.Services.Dialogs;
using XamlBrewer.UWP.MvvmToolkit.Sample.Services.Logging;
using XamlBrewer.UWP.MvvmToolkit.Sample.Services.Messenger.Messages;

namespace XamlBrewer.UWP.MvvmToolkit.Sample.ViewModels
{
    public class ColorModuleViewModel : MyViewModelBase
    {
        private Color _color;
        private Theme _theme;
        private ILoggingService _loggingService; // = Ioc.Default.GetService<ILoggingService>();
        private ModalView _dialogService;

        public ColorModuleViewModel(ILoggingService loggingService, ModalView modalView)
        {
            _loggingService = loggingService;
            _dialogService = modalView;

            // 'ThemeAwareViewModel'
            _theme = Messenger.Send<ThemeRequestMessage>();
            _loggingService.Log($"ColorModule requested theme and received {_theme.Name}.");
            if (_theme.Name == "Red")
            {
                Color = Colors.Red;
            }
            else
            {
                Color = Colors.Blue;
            }
        }

        public Color Color
        {
            get => _color;
            set => SetProperty(ref _color, value);
        }

        public void LogColor()
        {
            _loggingService.Log($"ColorModule confirms that the color is {ColorHelper.ToDisplayName(_color)}.");
        }

        public async Task<bool> GetUserConsentAsync()
        {
            return await _dialogService.ConfirmationDialogAsync("Do you like this color?", "I'm excited!", "It's gross ...");
        }

        protected override void OnActivated()
        {
            base.OnActivated();

            Messenger.Register<ThemeChangedMessage>(this, m =>
            {
                _loggingService.Log($"ColorModule received change to {m.Value.Name}.");

                if (m.Value.Name == "Red")
                {
                    Color = Colors.Red;
                }
                else
                {
                    Color = Colors.Blue;
                }
            });
        }

        // Note: This is handled automatically by ViewModelBase
        //protected override void OnDeactivated()
        //{
        //    // Messenger.Unregister(this, t); auto
        //    base.OnDeactivated();
        //}
    }
}

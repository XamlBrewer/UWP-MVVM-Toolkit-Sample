using Microsoft.Extensions.DependencyInjection;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
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
        private int t;
        private Theme _theme;
        private ILoggingService _loggingService; // = Ioc.Default.GetService<ILoggingService>();
        private ModalView _dialogService;

        public ColorModuleViewModel(ILoggingService loggingService, ModalView modalView)
        {
            _loggingService = loggingService;
            _dialogService = modalView;

            // 'ThemeAwareViewModel'
            _theme = Messenger.Send(new ThemeRequestMessage(), t);
            _loggingService.Log($"ColorModule requested thema and received {_theme.Name}.");
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
            set => Set(ref _color, value);
        }

        public void LogColor()
        {
            // For a more generic conversion, go here:
            // https://stackoverflow.com/questions/26188529/how-to-convert-a-windows-ui-color-into-a-string-color-name-in-a-windows-universa
            
            _loggingService.Log($"ColorModule confirms that the color is {(_color == Colors.Red ? "Red" : "Blue")}.");
        }

        public async Task<bool> GetUserConsentAsync()
        {
            return await _dialogService.ConfirmationDialogAsync("Do you like this color?", "I'm excited!", "It's gross ...");
        }

        protected override void OnActivated()
        {
            base.OnActivated();

            Messenger.Register<ThemeChangedMessage, int>(this, t, m =>
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

        //protected override void OnDeactivated()
        //{
        //    // Messenger.Unregister(this, t); auto
        //    base.OnDeactivated();
        //}
    }
}

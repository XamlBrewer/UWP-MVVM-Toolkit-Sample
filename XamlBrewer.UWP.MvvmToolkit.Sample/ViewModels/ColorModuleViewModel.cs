using Microsoft.Extensions.DependencyInjection;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Windows.UI;
using XamlBrewer.UWP.MvvmToolkit.Sample.Models;
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

        public ColorModuleViewModel(ILoggingService loggingService)
        {
            _loggingService = loggingService;

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

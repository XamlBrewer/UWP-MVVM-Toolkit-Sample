using Microsoft.Toolkit.Mvvm.Messaging;
using Windows.UI;
using XamlBrewer.UWP.MvvmToolkit.Sample.Models;
using XamlBrewer.UWP.MvvmToolkit.Sample.Services.Messenger.Messages;

namespace XamlBrewer.UWP.MvvmToolkit.Sample.ViewModels
{
    public class MemoryLeakingModuleViewModel : MyViewModelBase
    {
        private Color _color;
        private Theme _theme;

        public MemoryLeakingModuleViewModel()
        {
            // 'ThemeAwareViewModel'
            _theme = Messenger.Send(new ThemeRequestMessage());
            LoggingService.Log($"MemoryLeakingModule requested theme and received {_theme.Name}.");
            if (_theme.Name == "Red")
            {
                Color = Colors.Red;
            }
            else
            {
                Color = Colors.Blue;
            }

            Messenger.Register<ThemeChangedMessage>(this, m =>
            {
                LoggingService.Log($"MemoryLeakingModule received change to {m.Value.Name}.");

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

        public Color Color
        {
            get => _color;
            set => Set(ref _color, value);
        }
    }
}

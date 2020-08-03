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
            _theme = Messenger.Send<ThemeRequestMessage>();
            LoggingService.Log($"MemoryLeakingModule requested theme and received {_theme.Name}.");
            if (_theme.Name == "Red")
            {
                Color = Colors.Red;
            }
            else
            {
                Color = Colors.Blue;
            }

            // Note: This should normally be done in OnActivated, but we're showing the memory leak in this example by registering it here.
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
            set => SetProperty(ref _color, value);
        }
    }
}

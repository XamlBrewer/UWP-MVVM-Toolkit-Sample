using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Messaging;
using XamlBrewer.UWP.MvvmToolkit.Sample.Models;
using XamlBrewer.UWP.MvvmToolkit.Sample.Services.Messenger.Messages;

namespace XamlBrewer.UWP.MvvmToolkit.Sample.ViewModels
{
    public class ShellViewModel : ViewModelBase
    {
        private Theme _theme = Theme.Default;

        public ShellViewModel()
        {
            Messenger.Register<ThemeRequestMessage>(this, m =>
            {
                m.Reply(_theme); 
            });

            Messenger.Register<ThemeChangedMessage>(this, m =>
            {
                _theme = m.Value;
            });
        }
    }
}

using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Messaging;
using XamlBrewer.UWP.MvvmToolkit.Sample.Models;
using XamlBrewer.UWP.MvvmToolkit.Sample.Services.Messenger.Messages;

namespace XamlBrewer.UWP.MvvmToolkit.Sample.ViewModels
{
    public class ShellViewModel : ObservableRecipient
    {
        private Theme _theme = Theme.Default;

        public ShellViewModel()
        {
            Messenger.Register<ThemeRequestMessage>(this, (r, m) =>
            {
                m.Reply(_theme); 
            });

            Messenger.Register<ThemeChangedMessage>(this, (r, m) =>
            {
                _theme = m.Value;
            });
        }
    }
}

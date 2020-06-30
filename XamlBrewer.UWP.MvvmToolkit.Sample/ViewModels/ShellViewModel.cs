using Microsoft.Toolkit.Mvvm.ComponentModel;
using XamlBrewer.UWP.MvvmToolkit.Sample.Models;
using XamlBrewer.UWP.MvvmToolkit.Sample.Services.Messenger.Messages;

namespace XamlBrewer.UWP.MvvmToolkit.Sample.ViewModels
{
    public class ShellViewModel : ViewModelBase
    {
        private int t;
        private Theme _theme = Theme.Default;

        public ShellViewModel()
        {
            Messenger.Register<ThemeRequestMessage, int>(this, t, m =>
            {
                m.Reply(_theme); 
            });

            Messenger.Register<ThemeChangedMessage, int>(this, t, m =>
            {
                _theme = m.Value;
            });
        }
    }
}

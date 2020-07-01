using Microsoft.Toolkit.Mvvm.Messaging.Messages;
using XamlBrewer.UWP.MvvmToolkit.Sample.Models;

namespace XamlBrewer.UWP.MvvmToolkit.Sample.Services.Messenger.Messages
{
    public class ThemeChangedMessage : ValueChangedMessage<Theme>
    {
        public ThemeChangedMessage(Theme value) : base(value)
        {
        }
    }
}

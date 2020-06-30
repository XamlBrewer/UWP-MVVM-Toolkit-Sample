using Microsoft.Toolkit.Mvvm.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

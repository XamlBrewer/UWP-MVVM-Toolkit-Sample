using Microsoft.Toolkit.Mvvm.Messaging; // Hosts the 'Register' extension method without token
using Microsoft.Toolkit.Mvvm.ComponentModel;
using XamlBrewer.UWP.MvvmToolkit.Sample.Services.Messenger.Messages;
using System.Collections.Generic;
using System;

namespace XamlBrewer.UWP.MvvmToolkit.Sample.ViewModels
{
    public class CameraModuleViewModel : ViewModelBase
    {
        private string _reaction;
        private List<string> _reactions = new List<string>
            {
                "Click!",
                "Focusing...",
                "Is this on?",
                "Flash!",
                "Hold on..."
            };
        private Random rnd = new Random();

        public string Reaction
        {
            get => _reaction;
            set => Set(ref _reaction, value);
        }

        protected override void OnActivated()
        {
            base.OnActivated();

            // Does not see the messages with a token.
            Messenger.Register<CasualtyMessage>(this, m => { OnCasualtyMessageReceived(); });

            // So we need to know all the tokens and register for them - or the sender has to send twice.
            // Sending twice (empty message without token, and detailed message with token) is the safer approach.
            Messenger.Register<CasualtyMessage, string>(this, "blanket", m => { OnCasualtyMessageReceived(); });
            Messenger.Register<CasualtyMessage, string>(this, "pillow", m => { OnCasualtyMessageReceived(); });
        }

        private void OnCasualtyMessageReceived()
        {
            Reaction = _reactions[rnd.Next(0, 5)];
        }
    }
}

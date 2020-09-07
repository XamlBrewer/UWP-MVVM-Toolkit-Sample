using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using XamlBrewer.UWP.MvvmToolkit.Sample.Models;
using XamlBrewer.UWP.MvvmToolkit.Sample.Services.Messenger.Messages;

namespace XamlBrewer.UWP.MvvmToolkit.Sample.ViewModels
{
    public class BlanketModuleViewModel : ObservableRecipient
    {
        private string _reaction;
        private List<string> _reactions = new List<string>
            {
                "Oops!",
                "Ouch!",
                "Not good!",
                "Aww!",
                "D'oh!"
            };
        private Random rnd = new Random();

        public string Reaction
        {
            get => _reaction;
            set => SetProperty(ref _reaction, value);
        }

        protected override void OnActivated()
        {
            base.OnActivated();

            // Messenger.Register<CasualtyMessage, string>(this, "blanket", m => { OnCasualtyMessageReceived(); });
            Messenger.Register<CasualtyMessage, Party>(this, Party.Blanket, m => { OnCasualtyMessageReceived(); });
        }

        private void OnCasualtyMessageReceived()
        {
            Reaction = _reactions[rnd.Next(0, 5)];
        }
    }
}

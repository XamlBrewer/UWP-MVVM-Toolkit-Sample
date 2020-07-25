using Microsoft.Toolkit.Mvvm.ComponentModel;
using XamlBrewer.UWP.MvvmToolkit.Sample.Services.Messenger.Messages;

namespace XamlBrewer.UWP.MvvmToolkit.Sample.ViewModels
{
    public class PillowModuleViewModel : ViewModelBase
    {
        private string _reaction;

        public string Reaction
        {
            get => _reaction;
            set => Set(ref _reaction, value);
        }

        protected override void OnActivated()
        {
            base.OnActivated();

            Messenger.Register<CasualtyMessage, string>(this, "pillow", m => { OnCasualtyMessageReceived(); });
        }

        private void OnCasualtyMessageReceived()
        {
            Reaction = "Ouch!";
        }
    }
}

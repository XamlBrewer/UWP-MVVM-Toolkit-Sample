using Microsoft.Toolkit.Mvvm.Messaging;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using XamlBrewer.UWP.MvvmToolkit.Sample.Models;
using XamlBrewer.UWP.MvvmToolkit.Sample.Services.Messenger.Messages;
using XamlBrewer.UWP.MvvmToolkit.Sample.ViewModels;

namespace XamlBrewer.UWP.MvvmToolkit.Sample.Views
{
    public sealed partial class MessengerWithTokenPage : Page
    {

        public MessengerWithTokenPage()
        {
            this.InitializeComponent();
        }

        private void PillowModule_Loaded(object sender, RoutedEventArgs e)
        {
            PillowModuleViewModel.IsActive = true;
        }

        private void PillowModule_Unloaded(object sender, RoutedEventArgs e)
        {
            PillowModuleViewModel.IsActive = false;
        }

        private void PillowButton_Click(object sender, RoutedEventArgs e)
        {
            ClearReactions();
            // Messenger.Default.Send<CasualtyMessage, string>(new CasualtyMessage(), "pillow");
            Messenger.Default.Send<CasualtyMessage, Party>(new CasualtyMessage(), Party.Pillow);
        }

        private void BlanketModule_Loaded(object sender, RoutedEventArgs e)
        {
            BlanketModuleViewModel.IsActive = true;
        }

        private void BlanketModule_Unloaded(object sender, RoutedEventArgs e)
        {
            BlanketModuleViewModel.IsActive = false;
        }

        private void BlanketButton_Click(object sender, RoutedEventArgs e)
        {
            ClearReactions();
            // Messenger.Default.Send<CasualtyMessage>();
            // Messenger.Default.Send<CasualtyMessage, string>(new CasualtyMessage(), "blanket");
            Messenger.Default.Send<CasualtyMessage, Party>(new CasualtyMessage(), Party.Blanket);
        }

        private void CameraModule_Loaded(object sender, RoutedEventArgs e)
        {
            CameraModuleViewModel.IsActive = true;
        }

        private void CameraModule_Unloaded(object sender, RoutedEventArgs e)
        {
            CameraModuleViewModel.IsActive = false;
        }

        private void ClearReactions()
        {
            PillowModuleViewModel.Reaction = string.Empty;
            BlanketModuleViewModel.Reaction = string.Empty;
            CameraModuleViewModel.Reaction = string.Empty;
        }
    }
}

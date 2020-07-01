using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace XamlBrewer.UWP.MvvmToolkit.Sample.Views
{
    public sealed partial class MessengerPage : Page
    {
        public MessengerPage()
        {
            this.InitializeComponent();
        }

        private void ColorModule_Loaded(object sender, RoutedEventArgs e)
        {
            ColorModuleViewModel.IsActive = true;
        }

        private void ColorModule_Unloaded(object sender, RoutedEventArgs e)
        {
            ColorModuleViewModel.IsActive = false;
        }

        private void PictureModule_Loaded(object sender, RoutedEventArgs e)
        {
            PictureModuleViewModel.IsActive = true;
        }

        private void PictureModule_Unloaded(object sender, RoutedEventArgs e)
        {
            PictureModuleViewModel.IsActive = false;
        }
    }
}

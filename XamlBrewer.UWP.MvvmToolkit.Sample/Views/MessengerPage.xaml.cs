using Microsoft.Extensions.DependencyInjection;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using XamlBrewer.UWP.MvvmToolkit.Sample.ViewModels;

namespace XamlBrewer.UWP.MvvmToolkit.Sample.Views
{
    public sealed partial class MessengerPage : Page
    {
        private ColorModuleViewModel _colorModuleViewModel;

        public MessengerPage()
        {
            this.InitializeComponent();

            _colorModuleViewModel = Ioc.Default.GetService<ColorModuleViewModel>();
            ColorModule.DataContext = _colorModuleViewModel;
        }

        public ColorModuleViewModel ColorModuleViewModel => _colorModuleViewModel;

        private void ColorModule_Loaded(object sender, RoutedEventArgs e)
        {
            _colorModuleViewModel.IsActive = true;
        }

        private void ColorModule_Unloaded(object sender, RoutedEventArgs e)
        {
            _colorModuleViewModel.IsActive = false;
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

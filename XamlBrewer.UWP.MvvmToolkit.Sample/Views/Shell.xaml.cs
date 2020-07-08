using Microsoft.Extensions.DependencyInjection;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using System;
using Windows.ApplicationModel.Core;
using Windows.UI;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml.Controls;
using XamlBrewer.UWP.MvvmToolkit.Sample.Services.Dialogs;
using XamlBrewer.UWP.MvvmToolkit.Sample.Services.Logging;
using XamlBrewer.UWP.MvvmToolkit.Sample.ViewModels;
using WinUI = Microsoft.UI.Xaml.Controls;

namespace XamlBrewer.UWP.MvvmToolkit.Sample
{
    public sealed partial class Shell : Page
    {
        public Shell()
        {
            var coreTitleBar = CoreApplication.GetCurrentView().TitleBar;
            coreTitleBar.ExtendViewIntoTitleBar = true;

            var titleBar = ApplicationView.GetForCurrentView().TitleBar;
            if (titleBar != null)
            {
                titleBar.BackgroundColor = Colors.Transparent;
                titleBar.ButtonBackgroundColor = Colors.Transparent;
                titleBar.ButtonInactiveBackgroundColor = Colors.SlateGray;
                titleBar.ButtonForegroundColor = (Color)Resources["SystemAccentColor"];
            }

            Ioc.Default.ConfigureServices
                (services =>
                {
                    services.AddSingleton<ILoggingService, DebugLoggingService>();
                    services.AddSingleton<ColorModuleViewModel>();
                    services.AddSingleton<ModalView>();
                });

            // The following throws an 'already configured' InvalidOperationException
            // var loggingService = Ioc.Default.GetService<ILoggingService>();
            // Ioc.Default.ConfigureServices
            //     (services =>
            //     {
            //         services.Remove(new ServiceDescriptor(typeof(ILoggingService), loggingService));
            //     });

            this.InitializeComponent();
        }

        private void NavigationView_SelectionChanged(Microsoft.UI.Xaml.Controls.NavigationView sender, Microsoft.UI.Xaml.Controls.NavigationViewSelectionChangedEventArgs args)
        {
            if (args.IsSettingsSelected)
            {
                //ContentFrame.Navigate(typeof(SettingsPage));
                NavigationView.Header = "Settings";
                return;
            }

            var item = args.SelectedItemContainer as WinUI.NavigationViewItem;

            if (item.Tag != null)
            {
                ContentFrame.Navigate(Type.GetType(item.Tag.ToString()), item.Content);
                NavigationView.Header = item.Content;
            }
        }
    }
}

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using System;
using Windows.UI.Xaml.Controls;
using XamlBrewer.UWP.MvvmToolkit.Sample.Services.Logging;

namespace XamlBrewer.UWP.MvvmToolkit.Sample.Views
{
    public sealed partial class InversionOfControlPage : Page
    {
        public InversionOfControlPage()
        {
            this.InitializeComponent();
        }

        private void LogButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            var loggingService = Ioc.Default.GetService<ILoggingService>();

            // © Planet Trek.
            loggingService.Log($"Captain's Log - Stardate {DateTime.Now} - A friendly lifeform clicked the 'Log' button.");
        }
    }
}

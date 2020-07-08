using Microsoft.Extensions.DependencyInjection;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using System;
using Windows.UI.Xaml.Controls;
using XamlBrewer.UWP.MvvmToolkit.Sample.Services.Dialogs;
using XamlBrewer.UWP.MvvmToolkit.Sample.Services.Logging;
using XamlBrewer.UWP.MvvmToolkit.Sample.ViewModels;

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

        private async void DialogButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            var dialogService = Ioc.Default.GetService<ModalView>();
            var feedback = await dialogService.InputStringDialogAsync("What do you think of this app?", "It's amazing");
            if (!string.IsNullOrWhiteSpace(feedback))
            {
                var loggingService = Ioc.Default.GetService<ILoggingService>();
                await loggingService.Log($"We got some feedback: {feedback}.");
            }
        }

        private void AnotherLogButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            var viewModel = Ioc.Default.GetService<ColorModuleViewModel>();
            viewModel.LogColor();
        }

        private async void AnotherDialogButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            var viewModel = Ioc.Default.GetService<ColorModuleViewModel>();
            var consent = await viewModel.GetUserConsentAsync();

            var loggingService = Ioc.Default.GetService<ILoggingService>();
            await loggingService.Log($"The user {(consent ? "likes" : "hates")} the current theme color.");
        }
    }
}

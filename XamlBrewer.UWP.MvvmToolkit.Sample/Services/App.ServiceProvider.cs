﻿using Microsoft.Extensions.DependencyInjection;
using System;
using Windows.UI.Xaml;
using XamlBrewer.UWP.MvvmToolkit.Sample.Services.Dialogs;
using XamlBrewer.UWP.MvvmToolkit.Sample.Services.Logging;
using XamlBrewer.UWP.MvvmToolkit.Sample.ViewModels;

namespace XamlBrewer.UWP.MvvmToolkit.Sample
{
    /// <summary>
    /// ServiceProvider for the App.
    /// </summary>
    sealed partial class App : Application
    {
        public static IServiceProvider ServiceProvider { get; } = new ServiceCollection()
            .AddSingleton<ILoggingService, DebugLoggingService>()
            .AddSingleton<ColorModuleViewModel>()
            .AddSingleton<ModalView>()
            .BuildServiceProvider();
    }
}

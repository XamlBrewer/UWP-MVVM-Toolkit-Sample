using Microsoft.Toolkit.Mvvm.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Windows.UI.Xaml.Controls;

namespace XamlBrewer.UWP.MvvmToolkit.Sample.Views
{
    public sealed partial class InversionOfControlPage : Page
    {
        public InversionOfControlPage()
        {
            //Ioc.Default.ConfigureServices
            //    (s => s.Add());

            this.InitializeComponent();
        }
    }
}

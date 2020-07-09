using Microsoft.Extensions.DependencyInjection;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Microsoft.Toolkit.Mvvm.Messaging;
using System;
using Windows.UI.Xaml.Media.Imaging;
using XamlBrewer.UWP.MvvmToolkit.Sample.Models;
using XamlBrewer.UWP.MvvmToolkit.Sample.Services.Logging;
using XamlBrewer.UWP.MvvmToolkit.Sample.Services.Messenger.Messages;

namespace XamlBrewer.UWP.MvvmToolkit.Sample.ViewModels
{
    public class PictureModuleViewModel : MyViewModelBase
    {
        private BitmapImage _image;
        private Theme _theme;

        public PictureModuleViewModel()
        { }

        public BitmapImage Image
        {
            get => _image;
            set => Set(ref _image, value);
        }

        protected override void OnActivated()
        {
            base.OnActivated();

            var loggingService = Ioc.Default.GetService<ILoggingService>();

            _theme = Messenger.Send<ThemeRequestMessage>();
            loggingService.Log($"PictureModule requested theme and received {_theme.Name}.");
            UpdatePicture(_theme.Name);

            Messenger.Register<ThemeChangedMessage>(this, m =>
            {
                loggingService.Log($"PictureModule received change to {m.Value.Name}.");

                UpdatePicture(m.Value.Name);
            });
        }

        private void UpdatePicture(string themeName)
        {
            if (themeName == "Red")
            {
                Image = new BitmapImage(new Uri("ms-appx:///assets/inspectorspacetime.jpg"));
            }
            else
            {
                Image = new BitmapImage(new Uri("ms-appx:///assets/doctorwho.png"));
            }
        }
    }
}

using System;
using System.Diagnostics;
using Windows.UI.Xaml.Media.Imaging;
using XamlBrewer.UWP.MvvmToolkit.Sample.Models;
using XamlBrewer.UWP.MvvmToolkit.Sample.Services.Messenger.Messages;

namespace XamlBrewer.UWP.MvvmToolkit.Sample.ViewModels
{
    public class PictureModuleViewModel : MyViewModelBase
    {
        private BitmapImage _image;
        private int t;
        private Theme _theme;

        public PictureModuleViewModel()
        {
            // 'ThemeAwareViewModel'
            _theme = Messenger.Send(new ThemeRequestMessage(), t);
            Debug.WriteLine($"PictureModule requested thema and received {_theme.Name}.");
            if (_theme.Name == "Red")
            {
                Image = new BitmapImage(new Uri("ms-appx:///assets/inspectorspacetime.jpg"));
            }
            else
            {
                Image = new BitmapImage(new Uri("ms-appx:///assets/doctorwho.png"));
            }
        }

        public BitmapImage Image
        {
            get => _image;
            set => Set(ref _image, value);
        }

        protected override void OnActivated()
        {
            base.OnActivated();

            Messenger.Register<ThemeChangedMessage, int>(this, t, m =>
            {
                Debug.WriteLine($"PictureModule received change to {m.Value.Name}.");

                if (m.Value.Name == "Red")
                {
                    Image = new BitmapImage(new Uri("ms-appx:///assets/inspectorspacetime.jpg"));
                }
                else
                {
                    Image = new BitmapImage(new Uri("ms-appx:///assets/doctorwho.png"));
                }
            });
        }
    }
}

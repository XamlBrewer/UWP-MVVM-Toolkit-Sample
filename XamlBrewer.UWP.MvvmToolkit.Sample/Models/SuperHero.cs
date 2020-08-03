using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace XamlBrewer.UWP.MvvmToolkit.Sample.Models
{
    public class SuperHero : ObservableObject
    {
        private string _name;
        private string _nemesis;

        public SuperHero()
        { }

        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        public string Nemesis
        {
            get => _nemesis;
            set => SetProperty(ref _nemesis, value);
        }

        public string Tool { get; set; }
    }
}

using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace XamlBrewer.UWP.MvvmToolkit.Sample.Models
{
    public class SuperHero : ObservableObject
    {
        private string _name;
        private string _nemesis;

        public string Name
        {
            get => _name;
            set => Set(ref _name, value);
        }

        public string Nemesis
        {
            get => _nemesis;
            set => Set(ref _nemesis, value);
        }
    }
}

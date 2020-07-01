using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Windows.UI.Xaml.Controls;

namespace XamlBrewer.UWP.MvvmToolkit.Sample.Views
{
    public sealed partial class BuildingBlocksPage : Page
    {
        // https://www.grammar-monster.com/plurals/plural_of_nemesis.htm
        private List<string> _nemeses = new List<string>
            {
                "Lex Luthor",
                "Voldemort",
                "The Joker",
                "Gargamel",
                "Hydra"
            };

        private Random rnd = new Random();

        public BuildingBlocksPage()
        {
            this.InitializeComponent();
        }

        private void Button_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            ViewModel.SuperHero.Nemesis = _nemeses[rnd.Next(0, 5)];
        }
    }
}

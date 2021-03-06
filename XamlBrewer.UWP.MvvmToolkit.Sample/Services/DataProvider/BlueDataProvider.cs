﻿using XamlBrewer.UWP.MvvmToolkit.Sample.Models;

namespace XamlBrewer.UWP.MvvmToolkit.Sample.Services
{
    public class BlueDataProvider : IDataProvider
    {
        public string Description => "Blue Phonebox";

        public SuperHero SuperHero()
        {
            return new SuperHero
            {
                Name = "Doctor Who",
                Nemesis = "The Daleks",
                Tool = "Sonic Screwdriver"
            };
        }
    }
}

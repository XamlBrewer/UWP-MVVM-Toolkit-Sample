using XamlBrewer.UWP.MvvmToolkit.Sample.Models;

namespace XamlBrewer.UWP.MvvmToolkit.Sample.Services
{
    public class RedDataProvider : IDataProvider
    {
        public string Description => "Red Phonebox Data Provider";
        public SuperHero SuperHero()
        {
            return new SuperHero
            {
                Name = "Inspector Spacetime",
                Nemesis = "The Blorgons"
            };
        }
    }
}

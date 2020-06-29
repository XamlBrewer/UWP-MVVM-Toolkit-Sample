using XamlBrewer.UWP.MvvmToolkit.Sample.Models;

namespace XamlBrewer.UWP.MvvmToolkit.Sample.Services
{
    public interface IDataProvider
    {
        string Description { get; }
        SuperHero SuperHero();
    }
}

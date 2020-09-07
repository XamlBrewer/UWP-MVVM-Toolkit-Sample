using System;

namespace XamlBrewer.UWP.MvvmToolkit.Sample.Models
{
    // IEquatable Enum pattern.
    public sealed class Party : IEquatable<Party>
    {
        public static readonly Party Pillow = new Party(1, nameof(Pillow));
        public static readonly Party Blanket = new Party(2, nameof(Blanket));

        public string Name { get; private set; }

        public int Id { get; private set; }

        private Party(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public bool Equals(Party other)
        {
            return Id == other.Id;
        }
    }
}

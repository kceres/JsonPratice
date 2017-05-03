using System;

namespace ConsoleApplication.JsonApp.Entities
{
    public class Item : IEquatable<Item>
    {
        public string name;
        public int price;

        public Item(string name, int price = 0)
        {
            this.name = name;
            this.price = price;
        }

        bool IEquatable<Item>.Equals(Item other)
        {
            if (other == null) return false;
            return (this.name.Equals(other.name));
        }
    }
}
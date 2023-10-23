using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharSheet20DataBinding
{
    public class Item
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Amount { get; set; }
        public int Weight { get; set; }
        public Item() { }
        public Item(string name, string description, int amount, int weight)
        {
            Name = name;
            Description = description;
            Amount = amount;
            Weight = weight;
        }
    }
}

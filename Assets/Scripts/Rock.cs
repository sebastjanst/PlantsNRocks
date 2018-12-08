using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts
{
    public class Rock
    {
        public string Name { get; set; }
        public int Ammount { get; set; }
        public string Description { get; set; }

        public Rock(string name, int ammount, string description)
        {
            Name = name;
            Ammount = ammount;
            Description = description;
        }
    }
}

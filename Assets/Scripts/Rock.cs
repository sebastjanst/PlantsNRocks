using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    public class Rock
    {
        public string Name { get; set; }
        public int Ammount { get; set; }
        public string Description { get; set; }
        public Sprite Sprite { get; set; }

        public Rock(string name, int ammount, Sprite sprite, string description)
        {
            Name = name;
            Ammount = ammount;
            Sprite = sprite;
            Description = description;
        }
    }
}

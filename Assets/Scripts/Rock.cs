using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    //the rock class which also holds the sprite of the rock
    public class Rock
    {
        public string Name { get; set; }//not used in game
        public int Ammount { get; set; }//the ammount of this type of rock that the player has
        public string Description { get; set; }//not used in game
        public Sprite Sprite { get; set; }//the single sprite of the rock

        public Rock(string name, int ammount, Sprite sprite, string description)
        {
            Name = name;
            Ammount = ammount;
            Sprite = sprite;
            Description = description;
        }
    }
}

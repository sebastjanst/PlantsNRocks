using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    public class Plant
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public int Reward { get; set; }
        public int GrowthRate { get; set; }
        public Sprite[] Sprites = new Sprite[5];

        public Plant(string name, int price, string description, int reward, int growthRate, Sprite[] sprites)
        {
            Name = name;
            Price = price;
            Description = description;
            Reward = reward;
            GrowthRate = growthRate;

            Sprites = sprites;
        }

        public int getReward()
        {
            return Reward;
        }

        public int buySeed(int CoinsOwned)
        {
            int Cost = 0;
            if(CoinsOwned >= Price)
            {
                Cost = Price;
            }

            return Cost;
        }
    }
}

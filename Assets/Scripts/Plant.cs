using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    //the plant class which also holds all the sprites of a plant including all of it's stages of growth
    public class Plant
    {
        public string Name { get; set; }//the name of the plant, currently not used in game
        public int Price { get; set; }//the price of the seed in the shop
        public string Description { get; set; }//not used
        public int Reward { get; set; }//how many coins are rewarded on harvest
        public int GrowthRate { get; set; }//how fast the plant will grow
        public Sprite[] Sprites = new Sprite[5];//there are 5 stages of growth, so 5 sprites are used

        public Plant(string name, int price, string description, int reward, int growthRate, Sprite[] sprites)
        {
            Name = name;
            Price = price;
            Description = description;
            Reward = reward;
            GrowthRate = growthRate;

            Sprites = sprites;
        }

        public int getReward()//returns the coin reward of the plant
        {
            return Reward;
        }

        public int getPrice()//returns the cost of the plant
        {
            return Price;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    public class Plant
    {
        private string _Name;
        private int _Price;
        private int _Reward;

        public string Name { get; set; }
        public int Price { get; set; }
        public Sprite[] Sprites = new Sprite[5];

        public Plant(string name, int price, int reward, Sprite[] sprites)
        {
            _Name = name;
            _Price = price;
            _Reward = reward;

            Sprites = sprites;
        }

        public int getReward()
        {
            return _Reward;
        }
    }
}

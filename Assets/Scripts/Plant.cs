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
        private int _price;

        public string Name { get; set; }
        public int Price { get; set; }
        public Sprite[] Sprites = new Sprite[5];

        public Plant(string name, int price, Sprite[] sprites)
        {
            _Name = name;
            _price = price;

            Sprites = sprites;
        }
        public Plant()
        {
        }
    }
}

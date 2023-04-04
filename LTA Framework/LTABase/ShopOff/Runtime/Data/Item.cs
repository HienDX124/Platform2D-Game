using System;
using System.Collections;
using System.Collections.Generic;
using LTA.Base.Item;
using UnityEngine;

namespace ShopCoin
{
    [Serializable]
    public class Item : PackItem
    {
        public float price;
        public Item(string itemName , int level, float price) : base(itemName, level)
        {
            this.price = price;
        }
    }
}
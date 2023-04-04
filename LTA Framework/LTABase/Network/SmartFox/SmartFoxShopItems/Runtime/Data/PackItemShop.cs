using LTA.Base.Item;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackItemShop : PackItem
{
    public string itemId;

    public string baseId;
    
    public int price;
    
    public string type;

    public PackItemShop(string itemId,string id, string name, int level, int price, string type) : base(name, level)
    {
        this.price = price;
        this.type = type;
        this.itemId = itemId;
        this.baseId = itemId;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LTA.Base.Item;

[System.Serializable]
public class AddMoreItemsEffectInfo : TimeEffectInfo
{
    public PackItem[] items;
}

public class AddMoreItemsEffectHandle : BaseUseItemWithTimeEffect<AddMoreItemsEffectInfo>
{
    [SerializeField]
    List<UseItemController> listuseItem = new List<UseItemController>();
    [SerializeField]
    List<UseItemsController> listuseItems = new List<UseItemsController>();
    public override void UseItem(Transform target)
    {
        UseItemsController useItems = target.GetComponent<UseItemsController>();
        listuseItems.Add(useItems);
        foreach (PackItem item in info.items)
        {
            listuseItem.Add(useItems.AddItem(item));
        }
    }

    public override void ResetTime()
    {
        foreach (UseItemsController useItems in listuseItems)
        {
            foreach (UseItemController useItem in listuseItem)
            {
                useItems.RemoveItem(useItem);
            }
        }
        listuseItem.Clear();
        listuseItems.Clear();
        base.ResetTime();
    }

}

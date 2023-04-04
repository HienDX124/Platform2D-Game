using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LTA.Base.Item;
public class RemoveItemsHandle : BaseUseItemEffect<ItemsInfo>
{
    public override void UseItem(Transform target)
    {
        UseItemsController useItems = target.GetComponent<UseItemsController>();
        if (useItems == null) return;
        foreach (PackItem packItem in ItemInfo.items)
        {
            useItems.RemoveItem(packItem.itemName);
        }
    }
}

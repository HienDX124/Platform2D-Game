using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LTA.Base.Item;
[System.Serializable]
public class ItemsInfo
{
    public PackItem[] items;
}

public class AddMoreItemsHandle : BaseUseItemEffect<ItemsInfo>
{
    public override void UseItem(Transform target)
    {
        UseItemsController useItems = target.GetComponent<UseItemsController>();
        if (useItems == null) return;
        foreach (PackItem packItem in ItemInfo.items)
        {
            useItems.AddItem(packItem);
        }
    }

}

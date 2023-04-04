using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LTA.Base.Item;
[System.Serializable]
public class ChangeItemsInfo
{
    public ChangeItemInfo[] items;
}


[System.Serializable]
public class ChangeItemInfo
{
    public PackItem item;
    public int index;
}
public class ChangeItemsHandle : BaseUseItemEffect<ChangeItemsInfo>
{
    // Start is called before the first frame update
    public override void UseItem(Transform target)
    {
        UseItemsController useItems = target.GetComponent<UseItemsController>();
        if (useItems == null) return;
        foreach (ChangeItemInfo changeItemInfo in ItemInfo.items)
        {
            useItems.AddItem(changeItemInfo.item,changeItemInfo.index);
        }
    }
}

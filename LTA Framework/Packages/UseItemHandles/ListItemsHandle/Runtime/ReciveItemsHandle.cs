using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LTA.Base.Item;

[System.Serializable]
public class ReciveItemsInfo
{
    public PackItem[] items;
}

public class ReciveItemsHandle : BaseOnBeUseItemController,IOnUpLevel
{
    PackItem[] items;

    IOnReciveItem[] onReciveItems;

    protected void Awake()
    {
        Main.AddOnBeUseItemHandle<ListItemsInfo>(this);
        
    }

    public override void OnBeUseItem(object info)
    {
        ListItemsInfo listItemsInfo = (ListItemsInfo)info;
        if (listItemsInfo == null) return;
        if (items == null || items.Length == 0) return;
        foreach (PackItem reciveItem in items)
        {
            PackItem packItem = new PackItem(reciveItem.itemName, reciveItem.level);
            ListUtils<PackItem>.AddObjRespond(listItemsInfo.listName, packItem);
        }
        onReciveItems = GetComponentsInChildren<IOnReciveItem>();
        foreach (IOnReciveItem onReciveItem in onReciveItems)
        {
            onReciveItem.OnReciveItem(items);
        }
    }

    public void OnUpLevel(int level)
    {
        
        ReciveItemsInfo reciveItemsInfo = ListItemsDataController.Instance.reciveItemsVO.GetData<ReciveItemsInfo>(name, level);
        if (reciveItemsInfo == null) return;
        items = reciveItemsInfo.items;
    }
}

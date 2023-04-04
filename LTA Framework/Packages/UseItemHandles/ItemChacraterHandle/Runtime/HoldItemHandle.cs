using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using LTA.Base.Item;

[System.Serializable]
public class HoldItemInfo
{
    public string path = "";
    public string holdObjectName = "";
    public Vector3 localPos = Vector3.zero;
}


public class HoldItemHandle : BaseUseItemEffect<HoldItemInfo>,IAddItemsInfo,IEndLoadAnimation
{
    public void OnAddItemsInfo(int index, PackItem item, UseItemController useItem)
    {
        throw new System.NotImplementedException();
    }
    GameObject holdItem;
    public void OnEndLoadAnimtion()
    {
        GameObject prefabItem = GlobalVO.GetAsset.GetAsset<GameObject>(ItemInfo.path);
        Transform holdItemPos = transform.Find(ItemInfo.holdObjectName);
        holdItem = Instantiate(prefabItem, holdItemPos);
        holdItem.transform.localPosition = ItemInfo.localPos;
    }
    private void OnDestroy()
    {
        if (holdItem != null)
            Destroy(holdItem);
    }
}

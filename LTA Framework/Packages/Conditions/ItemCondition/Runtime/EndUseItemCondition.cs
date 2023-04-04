using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LTA.Condition;
using System;
using LTA.Base.Item;
[System.Serializable]
public class ItemConditionInfo
{
    public string itemName;
}

public class EndUseItemCondition : BaseConditionEffect<ItemConditionInfo>, IOnEndUseItem, IResetCondition
{
    public void OnEndUseItem(Transform[] targets,PackItem packItem)
    {
        if (packItem.itemName == EffectInfo.itemName)
            OnSuitableCondition(true);
    }

    public void ResetCondition()
    {
        isSuitable = false;
    }
}

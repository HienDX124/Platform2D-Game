using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LTA.Condition;
using LTA.Base.Item;
public class BeUseItemCondition : BaseConditionEffect<ItemConditionInfo>,IBeUseItem,IResetCondition
{
    public void OnBeUseItem(PackItem packItem)
    {
        if (packItem.itemName == EffectInfo.itemName)
            OnSuitableCondition(true);
    }

    public void ResetCondition()
    {
        isSuitable = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LTA.Condition;
using LTA.Base.Item;

[System.Serializable]
public class CountReciveItemCoditionInfo
{
    public int maxReciveItem;
}

public class CountReciveItemCodition : BaseConditionEffect<CountReciveItemCoditionInfo>, IOnReciveItem,IResetCondition
{
    int countReciveItem = 0;

    public void OnReciveItem(PackItem[] items)
    {
        countReciveItem++;
        Debug.Log(countReciveItem + " " + EffectInfo.maxReciveItem);
        if (countReciveItem == EffectInfo.maxReciveItem)
        {
            OnSuitableCondition(true);
            countReciveItem = 0;
        }
    }

    public void ResetCondition()
    {
        isSuitable = false;
    }
}

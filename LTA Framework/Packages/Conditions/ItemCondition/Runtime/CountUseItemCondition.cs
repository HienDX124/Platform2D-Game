using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LTA.Condition;
using LTA.Base.Item;

[System.Serializable]
public class CountUseItemInfo : ItemConditionInfo
{

    public int countUseItem;

    public int countDownReset = 0;

    public bool fistValue = false;
}

public class CountUseItemCondition : BaseConditionEffect<CountUseItemInfo>, IOnUseItem,IResetCondition
{
    [SerializeField]
    int countDown = 0;

    public override object Info {
        set
        {
            base.Info = value;
            isSuitable = EffectInfo.fistValue;
            if (isSuitable)
                OnSuitableCondition(true);
        }
    }

    public void OnUseItem(PackItem packItem)
    {
        if (packItem.itemName == EffectInfo.itemName)
            countDown++;
        if (countDown >= EffectInfo.countUseItem)
        {
            OnSuitableCondition(true);
        }
    }
    public void ResetCondition()
    {
        countDown = EffectInfo.countDownReset;
        isSuitable = false;
    }
}

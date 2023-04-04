using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LTA.Condition;
public class PercentInfo
{
    public float percent;
}

public class PercentCondition : BaseConditionEffect<PercentInfo>,IResetCondition
{
    public override bool IsSuitable
    {
        get
        {
            int percent = Random.Range(1, 1000000000) % 100;
            if (percent < info.percent)
                OnSuitableCondition(true);
            else
                isSuitable = false;
            return base.IsSuitable;
        }
    }

    public void ResetCondition()
    {
        isSuitable = false;
    }
}

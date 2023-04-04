using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LTA.Condition;
using System;

public class DieCondition : BaseCondition,IOnDie
{

    public void OnDie()
    {
        OnSuitableCondition(true);
    }

    public void ResetCondition()
    {
        isSuitable = false;
    }
}

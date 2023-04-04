using System;
using LTA.Condition;
using UnityEngine;
public class FirstCondition : BaseCondition,IResetCondition
    {
    private void Awake()
    {
        isSuitable = true;
    }

    public void ResetCondition()
        {
            isSuitable = false;
        }
    }
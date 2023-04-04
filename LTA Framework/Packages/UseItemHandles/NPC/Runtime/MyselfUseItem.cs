using System.Collections;
using System.Collections.Generic;
using LTA.Base.Item;
using UnityEngine;
using LTA.Condition;
using LTA.AutoTarget;

public class MyselfUseItem : NPCUseItem
{
    protected override IAutoTarget GetAutoTargets()
    {
        IAutoTarget autoTargets = GetComponent<MyselfTargetController>();
        if (autoTargets == null)
            autoTargets = gameObject.AddComponent<MyselfTargetController>();
        return autoTargets;
    }


    public override int numTarget => 1;
}

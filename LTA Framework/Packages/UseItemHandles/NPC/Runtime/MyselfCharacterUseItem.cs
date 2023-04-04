using System.Collections;
using System.Collections.Generic;
using LTA.AutoTarget;
using UnityEngine;

public class MyselfCharacterUseItem : NPCCharacterUseItem
{
    protected override IAutoTarget GetAutoTargets()
    {
        IAutoTarget autoTargets = GetComponent<MyselfTargetController>();
        if (autoTargets == null)
            autoTargets = gameObject.AddComponent<MyselfTargetController>();
        return autoTargets;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LTA.Base.Item;
using LTA.AutoTarget;
public class RemoveTargetHandle : BaseUseItem
{
    public override void UseItem(Transform target)
    {
        TargetController target1 = target.GetComponent<TargetController>();
        Destroy(target1);
    }

}

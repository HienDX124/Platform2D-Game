using System.Collections;
using System.Collections.Generic;
using LTA.Base.Item;
using UnityEngine;
public class OneKillController : BaseUseItem
{

    public override void UseItem(Transform target)
    {
        target.GetComponentInChildren<HPController>().CurrentHP = 0;
    }
}

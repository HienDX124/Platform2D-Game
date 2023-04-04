using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LTA.Base;
public class TargetDistanceInfo
{
    public float minRange;
    public float maxRange;
}

public class TargetDistance : MonoBehaviour,ISetInfo,ICheckTarget
{
    TargetDistanceInfo info;

    public object Info { set
        {
            info = (TargetDistanceInfo)value;
        }
    }

    public TargetDistanceInfo TargetDistanceInfo
    {
        get
        {
            return info;
        }
    }

    public bool CheckTarget(Transform target)
    {
        float distance = Vector3.Distance(transform.position, target.position);
        return (distance >= info.minRange && distance <= info.maxRange);
    }
}

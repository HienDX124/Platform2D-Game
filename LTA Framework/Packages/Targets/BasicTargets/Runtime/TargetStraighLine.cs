using System.Collections;
using System.Collections.Generic;using LTA.Base;
using UnityEngine;

public class TargetStraighLineInfo
{
    public float minY;
    public float maxY;
}
public class TargetStraighLine : MonoBehaviour,ISetInfo,ICheckTarget
{
    TargetStraighLineInfo info;

    public object Info { set
        {
            info = (TargetStraighLineInfo)value;
        }
    }

    public TargetStraighLineInfo TargetDistanceInfo
    {
        get
        {
            return info;
        }
    }

    public bool CheckTarget(Transform target)
    {
        float distanceY = Mathf.Abs(transform.position.y - target.position.y);
        return distanceY <= (info.maxY - info.minY);
    }
}

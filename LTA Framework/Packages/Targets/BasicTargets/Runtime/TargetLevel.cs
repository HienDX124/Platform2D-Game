using System.Collections;
using System.Collections.Generic;
using LTA.Base;
using UnityEngine;
[System.Serializable]
public class TargetLevelInfo
{
    public int level;
}

public class TargetLevel : MonoBehaviour, ISetInfo, ICheckTarget
{

    TargetLevelInfo info;

    public object Info
    {
        set
        {
            info = (TargetLevelInfo)value;
        }
    }

    public bool CheckTarget(Transform target)
    {
        NonEntityController nonEntityController = target.GetComponent<NonEntityController>();
        if (nonEntityController == null) return false;
        return nonEntityController.Level == info.level;
    }

}

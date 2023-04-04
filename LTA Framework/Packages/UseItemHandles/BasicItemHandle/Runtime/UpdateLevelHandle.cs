using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LTA.Base.Item;
[System.Serializable]
public class UpdateLevelInfo
{
    public int level;
    public int maxLevel;
}

public class UpdateLevelHandle : BaseUseItemEffect<UpdateLevelInfo>
{
    public override void UseItem(Transform target)
    {
        NonEntityController nonEntityController = target.GetComponent<NonEntityController>();
        Debug.LogError("UpdateLevelHandle " + info.level + " " + nonEntityController.Level + " " + info.maxLevel);
        if (nonEntityController.Level >= info.maxLevel && info.maxLevel > 0) return;
        if (nonEntityController != null) nonEntityController.SetLevel(nonEntityController.Level + info.level);
    }

}

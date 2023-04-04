using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LTA.Condition;
using LTA.Base.Item;

[System.Serializable]
public class NPCGetTargetConditionInfo
{
    public string itemName;
    public int numTarget;
}
public class NPCGetTargetCondition : BaseConditionEffect<NPCGetTargetConditionInfo>, IResetCondition,IOnNPCGetTarget
{
    public void OnNPCGetTarget(PackItem packItem, List<Transform> targets, int numTarget)
    {
        if (targets.Count == info.numTarget && packItem.itemName == EffectInfo.itemName)
        {
            OnSuitableCondition(true);
        }
    }

    public void ResetCondition()
    {
        isSuitable = false;
    }
}

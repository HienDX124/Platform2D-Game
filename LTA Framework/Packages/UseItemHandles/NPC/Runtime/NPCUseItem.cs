using System.Collections;
using System.Collections.Generic;
using LTA.AutoTarget;
using LTA.Base.Item;
using UnityEngine;
[System.Serializable]
public class NPCItemInfo
{
    public int numTarget = 1;
    public bool isReturnNoTarget = true;
    public bool isChangeTarget = true;
}

//[RequireComponent(typeof(AutoTargetsController))]
public class NPCUseItem : BaseUseItemEffect<NPCItemInfo>, IGetTargetsAuto
{

    [SerializeField]
    IAutoTarget m_AutoTargets;
    protected virtual void Start()
    {
        m_AutoTargets = GetAutoTargets();
        m_AutoTargets.AddAutoTarget(this);
    }

    protected virtual IAutoTarget GetAutoTargets()
    {
        IAutoTarget autoTargets = GetComponent<AutoTargetsController>();
        if (autoTargets == null)
            autoTargets = gameObject.AddComponent<AutoTargetsController>();
        return autoTargets;
    }

    public virtual int numTarget => ItemInfo.numTarget;

    public FilterTargetController Filter
    {
        get
        {
            return OwnUseItem;
        }
    }

    public bool IsAllowAutoTarget {
        get {
            return OwnUseItem.IsAllowUseItem;
        }
        
    }

    public bool IsReturnNoTarget => ItemInfo.isReturnNoTarget;

    public bool IsChangeTarget => ItemInfo.isChangeTarget;

    public List<Transform> OldTargets => oldRargets;
    [SerializeField]
    protected List<Transform> oldRargets;

    public virtual void GetTarget(List<Transform> targets)
    {
        oldRargets = targets;
        OnGetTargets(targets);
        OwnUseItem.UseItem(targets.ToArray());
    }
    protected void OnGetTargets(List<Transform> targets)
    {
        IOnNPCGetTarget[] onNPCGetTargets = GetComponents<IOnNPCGetTarget>();
        foreach (IOnNPCGetTarget onNPCGetTarget in onNPCGetTargets)
        {
            onNPCGetTarget.OnNPCGetTarget(OwnUseItem.packItem, targets, ItemInfo.numTarget);
        }
    }

    private void OnDestroy()
    {
        if (m_AutoTargets == null) return;
        m_AutoTargets.RemoveAutoTarget(this);
    }
}

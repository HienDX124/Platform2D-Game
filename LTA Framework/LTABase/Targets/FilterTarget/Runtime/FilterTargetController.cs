using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FilterTargetController: MonoBehaviour
{
    protected List<ICheckTarget> targets = new List<ICheckTarget>();
    protected List<ICheckBestTarget> bestTargets = new List<ICheckBestTarget>();
    public List<ICheckTarget> Targets
    {
        get
        {
            return this.targets;
        }
    }

    public List<ICheckBestTarget> BestTargets
    {
        get
        {
            return this.bestTargets;
        }
    }

    public T GetTarget<T>() where T : class,ICheckTarget
    {
        foreach(ICheckTarget checkTarget in targets)
        {
            if (checkTarget is T) return (T)checkTarget;
        }
        return null;
    }

    public bool CheckTarget(Transform target)
    {
        foreach(ICheckTarget checkTarget in targets)
        {
            if (!checkTarget.CheckTarget(target)) return false;
        }
        return true;
    }

    public bool CheckBestTarget(Transform target1, Transform target2)
    {
        foreach (ICheckBestTarget checkTarget in bestTargets)
        {
            if (!checkTarget.CheckTarget(target1,target2)) return false;
        }
        return true;
    }
}

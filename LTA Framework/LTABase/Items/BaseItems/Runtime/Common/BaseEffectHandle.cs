using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LTA.Base.Item;
public abstract class BaseEffectHandle<T,M,V> : BaseUseItemWithTimeEffect<T> where T : TimeEffectInfo where M : Component
{
    protected M[] baseMains;

    protected V[] pevValues;

    public override void UseItem(Transform[] targets)
    {
        if (baseMains != null) return;
        baseMains = new M[targets.Length];
        pevValues = new V[targets.Length];
        for (int i = 0; i < targets.Length; i++)
        {
            if (targets[i] == null) continue;
            baseMains[i] = targets[i].GetComponentInChildren<M>();
            if (baseMains[i] == null) continue;
            UpdadeValue(i);
        }
        IsActive = true;
    }

    protected abstract void UpdadeValue(int index);
    protected abstract void ResetValue(int index);
    public override void ResetTime()
    {
        if (baseMains != null)
        {
            for (int i = 0; i < baseMains.Length; i++)
            {
                if (baseMains[i] == null) continue;
                ResetValue(i);
            }
            baseMains = null;
            pevValues = null;
        }
        base.ResetTime();
    }

    private void OnDestroy()
    {
        if (baseMains != null)
        {
            for (int i = 0; i < baseMains.Length; i++)
            {
                if (baseMains[i] == null) continue;
                ResetValue(i);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LTA.VO; 
public abstract class EntityController<VO,I> : MonoBehaviour,IOnUpLevel where VO : BaseMutilVO where I : class
{
    public void OnUpLevel(int level)
    {
        I info = GetVO().GetData<I>(name, level);
        if (info == null) throw new System.Exception(name  + "have no Data in level " +level);
        SetInfo(info);
    }

    protected abstract void SetInfo(I info);

    protected abstract VO GetVO();

}

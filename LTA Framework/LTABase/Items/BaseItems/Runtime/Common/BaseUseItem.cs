using LTA.Base.Item;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseUseItem : MonoBehaviour, IUseItem
{
    public virtual void UseItem(Transform[] targets)
    {
        foreach (Transform target in targets)
        {
            UseItem(target);
        }
    }

    public abstract void UseItem(Transform target);

    public UseItemController OwnUseItem
    {
        get
        {
            return ownUseItem;
        }
        set
        {
            ownUseItem = value;
        }
    }

    private UseItemController ownUseItem;
}

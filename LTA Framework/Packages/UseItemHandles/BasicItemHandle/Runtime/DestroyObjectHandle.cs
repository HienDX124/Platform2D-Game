using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LTA.Base.Item;

[System.Serializable]
public class DestroyObjectInfo
{
    public float timeToDestroy = 0f;
}

public class DestroyObjectHandle : BaseUseItemEffect<DestroyObjectInfo>
{
    public override void UseItem(Transform target)
    {
        StartCoroutine(IeDestroy(target));
    }

    IEnumerator IeDestroy(Transform target)
    {
        yield return new WaitForSeconds(info.timeToDestroy);
        Destroy(target.gameObject);
    }
}

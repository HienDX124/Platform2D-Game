using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LTA.Base.Item;

[System.Serializable]
public class MoveEffectInfo : TimeEffectInfo
{
    public float percentSpeed;
    public float speed;
}

public class MoveEffectHandle : BaseEffectHandle<MoveEffectInfo,MoveController, float>
{

    protected override void UpdadeValue(int i)
    {
        pevValues[i] = baseMains[i].speed * ItemInfo.percentSpeed + ItemInfo.speed;
        baseMains[i].speed += pevValues[i];
    }

    protected override void ResetValue(int i)
    {
        baseMains[i].speed -= pevValues[i];
    }
}

using UnityEngine;
using LTA.Base.Item;
using LTA.Base.Character;

[System.Serializable]
public class AnimEffectInfo : TimeEffectInfo
{
    public float percentSpeedAnim;
    public float speedAnim;
}

public class AnimEffectHandle : BaseEffectHandle<AnimEffectInfo,BaseAnimation,float>
{
    protected override void UpdadeValue(int i)
    {

        pevValues[i] = baseMains[i].speedAnim * ItemInfo.percentSpeedAnim + ItemInfo.speedAnim;
        baseMains[i].speedAnim += pevValues[i];
    }

    protected override void ResetValue(int i)
    {
        baseMains[i].speedAnim -= pevValues[i];
    }
}

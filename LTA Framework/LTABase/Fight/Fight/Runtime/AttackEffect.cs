using LTA.Base.Item;
[System.Serializable]
public class AttackEffectInfo : TimeEffectInfo
{
    public AttackInfo percent;
    public AttackInfo effect;
}

public class AttackEffect : BaseEffectHandle<AttackEffectInfo, AttackController, AttackInfo>
{
    protected override void ResetValue(int i)
    {
        baseMains[i].ItemInfo -= pevValues[i];
    }

    protected override void UpdadeValue(int i)
    {
        pevValues[i] = baseMains[i].ItemInfo * ItemInfo.percent + ItemInfo.effect;
        baseMains[i].ItemInfo += pevValues[i];
    }
}

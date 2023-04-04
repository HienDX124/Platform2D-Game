using UnityEngine;
using LTA.Base.Item;
using LTA.Base.Character;
[System.Serializable]
public class MotionLessInfo : TimeEffectInfo
{
    public string animName = "";
}

public class MotionLessHandle : BaseUseItemWithTimeEffect<MotionLessInfo>
{
    CharacterMotionLessController characterMotionLess;
    public override void UseItem(Transform target)
    {
        if (info.animName == "") return;
        
        CharateterStateController charateterState = target.GetComponentInChildren<CharateterStateController>();
        characterMotionLess = charateterState.GetComponent<CharacterMotionLessController>();
            if (characterMotionLess == null)
        characterMotionLess = charateterState.gameObject.AddComponent<CharacterMotionLessController>();
        characterMotionLess.SetCharacterMotionLess(info.animName);
    }

    public override void ResetTime()
    {
        base.ResetTime();
        Destroy(characterMotionLess); 
    }
}

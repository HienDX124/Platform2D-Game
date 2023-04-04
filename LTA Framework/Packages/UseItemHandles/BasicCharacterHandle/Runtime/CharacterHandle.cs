using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LTA.Base.Item;
public class CharacterInfo
{
    public string animName = "";
}

public class CharacterHandle : BaseUseItemEffect<CharacterInfo>
{
    public override void UseItem(Transform target)
    {
        base.UseItem(target);
    }
}

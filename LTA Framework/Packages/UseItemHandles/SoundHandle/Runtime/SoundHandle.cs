using System;
using System.Collections;
using System.Collections.Generic;
using LTA.Base.Item;
using UnityEngine;

[Serializable]
public class SoundInfo
{
    public string pathSoundEffect;
}
public class SoundHandle : BaseUseItemEffect<SoundInfo>
{
    public override void UseItem(Transform target)
    {
        Debug.Log("user item effect sound");
        MySound.Instance.PlaySound(info.pathSoundEffect);
    }
}

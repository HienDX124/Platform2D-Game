using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LTA.Effect;
using System;
using LTA.Base.Character;
public class CharacterEffect : BaseEffect
{
    [SerializeField]
    string animShow;

    [SerializeField]
    string animHide;
    IAnimation ianimation;

    IAnimation Animation
    {
        get
        {
            if (ianimation == null)
                ianimation = GetComponentInChildren<IAnimation>();
            return ianimation;
        }
    }

    public override void Hide()
    {
        Animation.Play(animHide);
    }

    public override void HideEffect(Action endEffect)
    {
        Animation.Play(animHide);
        if (endEffect != null)
            endEffect();
    }

    public override void HideEffect()
    {
        HideEffect(null);
    }

    public override void ShowEffect(Action endEffect)
    {
        Animation.Play(animShow);
        if (endEffect != null)
            endEffect();
    }

    public override void ShowEffect()
    {
        ShowEffect(null);
    }
}

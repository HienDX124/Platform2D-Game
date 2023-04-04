using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LTA.Effect;
using System;
using Spine.Unity;

[System.Serializable]
public class SpineEffectInfo
{
    public string anim;
    public string skinName;
    public bool loop;
}

public class UISpineAnimEffect : BaseEffect
{
    SkeletonGraphic skeletonGraphic;

    SkeletonGraphic SkeletonGraphic
    {
        get
        {
            if (skeletonGraphic == null)
            {
                skeletonGraphic = GetComponent<SkeletonGraphic>();
            }
            return skeletonGraphic;
        }
    }

    [SerializeField]
    SpineEffectInfo animShow;

    [SerializeField]
    SpineEffectInfo animHide;

    public SpineEffectInfo AnimShow
    {
        get => animShow;
        set => animShow = value;
    }

    public SpineEffectInfo AnimHide
    {
        get => animHide;
        set => animHide = value;
    }

    public override void Hide()
    {
        HideEffect(null);
    }

    public override void HideEffect(Action endEffect)
    {
        if(animShow.skinName != "default")
            this.SkeletonGraphic.Skeleton.SetSkin(animHide.skinName);
        // SkeletonGraphic.Initialize(true);
         this.SkeletonGraphic.AnimationState.Apply(SkeletonGraphic.Skeleton);
         this.SkeletonGraphic.Skeleton.SetSlotsToSetupPose();
        this.SkeletonGraphic.AnimationState.SetAnimation(0, animHide.anim, animHide.loop);
        if (endEffect != null) endEffect();
    }

    public override void HideEffect()
    {
        HideEffect(null);
    }

    public override void ShowEffect(Action endEffect)
    {
        if(animShow.skinName != "default")
            this.SkeletonGraphic.Skeleton.SetSkin(animShow.skinName);
        // SkeletonGraphic.Initialize(true);
         this.SkeletonGraphic.AnimationState.Apply(SkeletonGraphic.Skeleton);
         this.SkeletonGraphic.Skeleton.SetSlotsToSetupPose();
        this.SkeletonGraphic.AnimationState.SetAnimation(0, animShow.anim,animShow.loop);
        if (endEffect != null) endEffect();
    }

    public override void ShowEffect()
    {
        ShowEffect(null);
    }
}

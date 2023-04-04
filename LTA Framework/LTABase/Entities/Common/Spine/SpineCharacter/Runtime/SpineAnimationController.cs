using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
using Animation = Spine.Animation;
using System;
using Spine;
using LTA.Base.Character;
using Event = Spine.Event;
namespace LTA.Character.Spine
{
    public class SpineInfo
    {
        public string path;
        public string skinName;
        public bool isSpawnBones = false;
        public int layer = -1;
    }

    [RequireComponent(typeof(SkeletonAnimation))]
    public class SpineAnimationController : BaseAnimation
    {

        SkeletonAnimation skeleton;

        SkeletonAnimation Skeleton
        {
            get
            {
                if (skeleton == null)
                    skeleton = GetComponent<SkeletonAnimation>();
                return skeleton;
            }
        }

        private void HandleAnimationStartEvent(TrackEntry trackEntry)
        {
            if (startHandle != null) startHandle();
            startHandle = null;
        }

        private void HandleAnimationEndEvent(TrackEntry trackEntry)
        {
            Skeleton.timeScale = 1;
            if (endHandle != null) endHandle();
            endHandle = null;
        }

        private void HandleAnimationStateEvent(TrackEntry trackEntry, Event e)
        {
            string eventName = e.Data.Name;
            if (dic_EventHandle.ContainsKey(eventName))
            {
                dic_EventHandle[eventName]();
            }
        }

        public override bool CheckAnim(string animName)
        {
            return Skeleton.skeleton.Data.FindAnimation(animName) != null;
        }

        public override void Play(string animName, bool loop = true)
        {
            base.Play(animName, loop);
            Animation animation = Skeleton.skeleton.Data.FindAnimation(animName);
            float timeDelay = 1 / speedAnim;
            if (animation == null)
            {
                return;
            }
            if (animation.Duration > timeDelay)
            {
                Skeleton.timeScale = (float)animation.Duration / timeDelay;
            }
            skeleton.timeScale = 1;
            Skeleton.loop = loop;
            Skeleton.AnimationName = pre_Anim + animName;
        }

        public override void OnUpLevel(int level)
        {
            
            SpineInfo spineInfo = SpineDataController.Instance.spinesVO.GetData<SpineInfo>(OwnName, level);
            if (spineInfo == null) return;
            if (spineInfo.layer != -1)
                GetComponent<MeshRenderer>().sortingOrder = spineInfo.layer;
            SkeletonDataAsset asset = GlobalVO.GetAsset.GetAsset<SkeletonDataAsset>(spineInfo.path);
            Skeleton.skeletonDataAsset = asset;
            Skeleton.Initialize(true);
            if (!String.IsNullOrEmpty(spineInfo.skinName))
            {
                Skeleton.skeleton.SetSkin(spineInfo.skinName);
                Skeleton.Skeleton.SetSlotsToSetupPose();
                Skeleton.LateUpdate();
            }
            Skeleton.AnimationState.Start += HandleAnimationStartEvent;
            Skeleton.AnimationState.Event += HandleAnimationStateEvent;
            Skeleton.AnimationState.Complete += HandleAnimationEndEvent;
            if (spineInfo.isSpawnBones)
            {
                SkeletonUtility skeletonUtility = GetComponent<SkeletonUtility>();
                if (skeletonUtility == null) skeletonUtility = gameObject.AddComponent<SkeletonUtility>();
                skeletonUtility.SpawnHierarchy(SkeletonUtilityBone.Mode.Follow, true, true, true);
            }
            base.OnUpLevel(level);

        }

        public override int LayerOrder
        {
            set
            {
                GetComponent<MeshRenderer>().sortingOrder = value;
            }
            get
            {
                return GetComponent<MeshRenderer>().sortingOrder;
            }

        }

        public override float Height => Skeleton.skeleton.FindBone("All").ScaleX * Skeleton.skeleton.Data.Height;
    }
}

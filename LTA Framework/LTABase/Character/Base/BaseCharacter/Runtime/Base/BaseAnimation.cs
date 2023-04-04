using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationInfo
{
    public float speedAnim = 1f;
}
namespace LTA.Base.Character
{
    public abstract class BaseAnimation : MonoBehaviour, IAnimation,IOnUpLevel
    {
        protected Dictionary<string, Action> dic_EventHandle = new Dictionary<string, Action>();

        protected Action startHandle;

        protected Action endHandle;

        [SerializeField]
        public float speedAnim = 1f;

        public string pre_Anim = "";
        
        public string anim = "";

        protected string OwnName
        {
            get
            {
                return transform.parent.name;
            }
        }

        public abstract int LayerOrder { get; set; }

        public abstract float Height { get; }

        public abstract bool CheckAnim(string animName);

        public virtual void Play(string animName, bool loop = true)
        {
            anim = animName;
        }

        //public abstract void Play(string animName, float timeDelay, bool loop = true);

        public void SetEvent(string eventName, Action eventHandle)
        {
            if (!dic_EventHandle.ContainsKey(eventName))
            {
                dic_EventHandle.Add(eventName, eventHandle);
                return;
            }
            dic_EventHandle[eventName] = eventHandle;
        }

        public void SetStartEvent(Action eventHandle)
        {
            startHandle = eventHandle;
        }

        public void SetEndEvent(Action eventHandle)
        {
            endHandle = eventHandle;
            Debug.Log("End animation: " + anim);
            IEndAnimation[] endAnimations = transform.parent.GetComponents<IEndAnimation>();
            foreach (IEndAnimation endAnim in endAnimations)
            {
                endAnim.EndAnimation(anim);
            }
        }

        public void SetPreAnim(string preAnim)
        {
            this.pre_Anim = preAnim;
        }

        public virtual void OnUpLevel(int level)
        {
            if (!CharacterDataController.Instance.animationVO.CheckKey(OwnName)) return;
            AnimationInfo animationInInfo = CharacterDataController.Instance.animationVO.GetData<AnimationInfo>(OwnName,level);
            if (animationInInfo == null) return;
            speedAnim = animationInInfo.speedAnim;
            IEndLoadAnimation[] endLoadAnimations = transform.parent.GetComponents<IEndLoadAnimation>();
            foreach(IEndLoadAnimation endLoadAnimation in endLoadAnimations)
            {
                endLoadAnimation.OnEndLoadAnimtion();
            }
        }
    }
}

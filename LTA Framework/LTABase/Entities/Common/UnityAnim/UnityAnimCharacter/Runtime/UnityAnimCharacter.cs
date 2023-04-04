using UnityEngine;
namespace LTA.Base.Character.UnityAnim
{

    public class UnityAnimCharacter : BaseAnimation
    {
        Animator animator;

        protected Animator Animator
        {
            get
            {
                if (animator == null)
                    animator = GetComponent<Animator>();
                return animator;
            }
        }


        public override int LayerOrder
        {
            get => 1; set
            {
            }
        }

        public override float Height => 1f;

        AnimationClip[] animationClips;

        AnimationClip[] AnimationClips
        {
            get
            {
                if (animationClips == null)
                {
                    animationClips = Animator.runtimeAnimatorController.animationClips;
                }
                return animationClips;
            }

        }

        AnimationClip GetAnimatorClipInfo(string animName)
        {
            foreach (AnimationClip animationClip in AnimationClips)
            {
                if (animationClip.name == animName)
                    return animationClip;
            }
            return null;
        }

        public override bool CheckAnim(string animName)
        {
            return GetAnimatorClipInfo(animName) != null;
        }

        public override void Play(string animName, bool loop = true)
        {
            base.Play(animName, loop);
            if (currentAnim == animName) return;
            currentAnim = animName;
            AnimationClip animationClip = GetAnimatorClipInfo(animName);

            Animator.Rebind();
            Animator.Update(0f);

            Animator.speed = 1 / speedAnim;
            if (loop)
                animationClip.wrapMode = WrapMode.Loop;
            else
                animationClip.wrapMode = WrapMode.Once;
            Animator.Play(animName);
        }

        string currentAnim = "";


        public void StartAnim()
        {
            if (startHandle != null) startHandle();
            startHandle = null;
        }

        public void OnEvent(string eventName)
        {
            if (dic_EventHandle.ContainsKey(eventName))
            {
                dic_EventHandle[eventName]();
            }
        }

        public void EndAnim()
        {
            if (endHandle != null) endHandle();
            endHandle = null;
        }
    }
}

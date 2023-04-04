
using UnityEngine;



namespace LTA.Base.Character
{
    [RequireComponent(typeof(CharateterStateController))]
    public abstract class BaseCharaterController : BaseMainComponent<CharateterStateController>, ICharacterState
    {
        [SerializeField]
        protected string anim;
        protected string originanim;
        IAnimation animator;
        protected string state;
        protected IAnimation Animator
        {
            get
            {
                if (animator == null)
                {
                    animator = GetComponent<IAnimation>();
                }
                return animator;
            }
        }

        protected void AddCharaterState(string state)
        {
              this.state = state;
              Main.AddCharaterState(state, this);
        }

        public void ChangeAnim(string newAnim)
        {
            if (Animator.CheckAnim(newAnim))
            {
                anim = newAnim;
            }
            if (Main.CurrentState == state)
            {
                Animator.Play(anim);
            }
        }

        public void ResetAnim()
        {
            anim = originanim;
            if (Main.CurrentState == state)
            {
                Animator.Play(anim);
            }
        }

        protected string OwnName
        {
            get
            {
                return transform.parent.name;
            }
        }

        public abstract bool CheckCanChangeState(string state);
        public abstract void SetState(string state);

    }
}

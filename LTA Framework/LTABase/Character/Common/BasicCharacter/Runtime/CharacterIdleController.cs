using LTA.Base.Character;
using UnityEngine;
namespace LTA.BasicCharacter
{
    [DisallowMultipleComponent]
    public class CharacterIdleController : BaseCharaterController,IOnUpLevel
    {
        IOnCharacterIdle[] onCharacterIdles;
        protected virtual void Awake()
        {
            AddCharaterState(BasicState.Idle);
            onCharacterIdles = transform.parent.GetComponents<IOnCharacterIdle>();
        }

        protected virtual void Update()
        {
            if (Main.CurrentState == BasicState.Idle && onCharacterIdles != null)
            {
                foreach (IOnCharacterIdle onCharacterIdle in onCharacterIdles)
                    onCharacterIdle.Idle();
            }

        }

        public override void SetState(string state)
        {
            Animator.Play(anim);
        }

        public override bool CheckCanChangeState(string state)
        {
            return true;
        }

        public void OnUpLevel(int level)
        {
                originanim = CharacterDataController.Instance.charactersVO.GetAnimName(OwnName, level, BasicState.Idle);
                anim = originanim;
                Main.SetState(BasicState.Idle);

        }
    }
}

using UnityEngine;
using LTA.Move;
using LTA.Base.Character;
namespace LTA.BasicCharacter
{
    public class CharacterMoveController : BaseCharaterController,IOnUpLevel
    {

        IOnCharacterMove[] onCharacterMoves;

        MoveController moveController;


        protected MoveController MoveController
        {
            get
            {
                if (moveController == null)
                {
                    if (moveController == null)
                    {
                        moveController = transform.parent.gameObject.GetComponent<MoveController>();
                    }
                }
                return moveController;
            }
        }

        protected Vector3 direction = Vector3.zero;

        public virtual Vector3 Direction
        {
            set
            {
                direction = value.normalized;
                if (direction == Vector3.zero)
                {
                    Main.SetState(BasicState.Idle);
                    return;
                }
                if (Main.CurrentState == BasicState.Move)
                {
                    UpdateState(direction);
                    return;
                }
                Main.SetState(BasicState.Move);
            }
            get
            {
                return direction;
            }
        }

        void Awake()
        {
            AddCharaterState(BasicState.Move);
            onCharacterMoves = transform.parent.GetComponents<IOnCharacterMove>();
        }

        void FixedUpdate()
        {
            if (Main.CurrentState != BasicState.Move) return;
            MoveController.Move(direction);
            if (onCharacterMoves == null) return;
            foreach (IOnCharacterMove onCharacterMove in onCharacterMoves)
                onCharacterMove.OnMove(direction);
        }

        protected virtual void UpdateState(Vector3 direction)
        {
            Animator.Play(anim);
        }

        public override bool CheckCanChangeState(string state)
        {
            return true;
        }

        public override void SetState(string state)
        {
            UpdateState(direction);
        }

        public virtual void OnUpLevel(int level)
        {
            originanim= CharacterDataController.Instance.charactersVO.GetAnimName(OwnName,level,BasicState.Move);
            anim = originanim;
        }
    }
}

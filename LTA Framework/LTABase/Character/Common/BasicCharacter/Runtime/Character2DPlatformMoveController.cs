using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace LTA.BasicCharacter.Character2D.Platform
{
    public enum MoveState
    {
        Up,
        Down,
        None
    }
    public class Character2DPlatformMoveController : CharacterMoveController
    {
        MoveState moveState = MoveState.None;

        public override Vector3 Direction {
            set {
                if (value == Vector3.zero) moveState = MoveState.None;
                base.Direction = value;
            }
        }

        protected override void UpdateState(Vector3 direction)
        {
            if (direction.y > 0)
                moveState = MoveState.Up;
            else if (direction.y < 0)
                moveState = MoveState.Down;
            if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y) || direction.y == 0)
            {
                moveState = MoveState.None;
            }
            switch (moveState)
            {
                case MoveState.Up:
                    if (Animator.CheckAnim("move up"))
                    {
                        Animator.Play("move up");
                        return;
                    }
                    break;
                case MoveState.Down:
                    if (Animator.CheckAnim("move down"))
                    {
                        Animator.Play("move down");
                        return;
                    }
                    break;
            }
            if (direction.x < 0)
                transform.eulerAngles = new Vector3(0, 180, 0);
            else
                transform.eulerAngles = new Vector3(0, 0, 0);
            base.UpdateState(direction);
        }
    }

    
}

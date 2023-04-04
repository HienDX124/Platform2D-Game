using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace LTA.BasicCharacter.Character2D.Platform
{
    public class Character2DPlatformIdleController : CharacterIdleController
    {
        public override void SetState(string state)
        {
            Vector3 direction = transform.right;
            MoveState moveState = MoveState.None;
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
                    if (Animator.CheckAnim("idle up"))
                    {
                        Animator.Play("idle up");
                        return;
                    }
                    break;
                case MoveState.Down:
                    if (Animator.CheckAnim("idle down"))
                    {
                        Animator.Play("idle down");
                        return;
                    }
                    break;
            }
            if (direction.x < 0)
                transform.eulerAngles = new Vector3(0, 180, 0);
            else
                transform.eulerAngles = new Vector3(0, 0, 0);
            base.SetState(state);
        }
    }
}

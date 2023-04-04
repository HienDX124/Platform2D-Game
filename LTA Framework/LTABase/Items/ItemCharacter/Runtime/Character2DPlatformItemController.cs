using System.Collections;
using System.Collections.Generic;
using LTA.BasicCharacter.Character2D.Platform;
using UnityEngine;

public class Character2DPlatformItemController : CharacterItemController
{
    protected override Vector3 Direction { set
        {
            MoveState moveState = MoveState.None;
            if (value.y > 0)
                moveState = MoveState.Up;
            else if (value.y < 0)
                moveState = MoveState.Down;
            if (Mathf.Abs(value.x) > Mathf.Abs(value.y) || value.y == 0)
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
            if (value.x < 0)
                transform.eulerAngles = new Vector3(0, 180, 0);
            else
                transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }
}

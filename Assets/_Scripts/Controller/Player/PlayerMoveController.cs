using System.Collections;
using System.Collections.Generic;
using LTA.BasicCharacter;
using LTA.BasicCharacter.Character2D.Platform;
using UnityEngine;

public class PlayerMoveController : Character2DPlatformMoveController
{

    private Vector3 cachedVector3;

    public void Move(Vector3 dir)
    {
        this.Direction = dir;
    }

    public void StopMove()
    {
        this.Direction = Vector3.zero;
    }

    protected override void UpdateState(Vector3 direction)
    {
        base.UpdateState(direction);

        if (direction.x < 0)
            transform.eulerAngles = new Vector3(0, 180, 0);
        if (direction.x > 0)
            transform.eulerAngles = new Vector3(0, 0, 0);
    }
}
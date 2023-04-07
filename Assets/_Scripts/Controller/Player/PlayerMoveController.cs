using System.Collections;
using System.Collections.Generic;
using LTA.BasicCharacter;
using LTA.BasicCharacter.Character2D.Platform;
using UnityEngine;

public class PlayerMoveController : Character2DPlatformMoveController
{
    // [SerializeField] private Transform rendererTransform;
    private Vector3 cachedVector3;


    public void Move(Vector3 direction)
    {
        SetState(BasicState.Move);
        UpdateState(direction);
    }

    public void StopMove()
    {
        SetState(BasicState.Idle);
    }

    // public override void Move(Vector3 direction)
    // {
    //     cachedVector3.Set((direction.x > 0) ? Mathf.Abs(rendererTransform.localScale.x) : -Mathf.Abs(rendererTransform.localScale.x), rendererTransform.localScale.y, rendererTransform.localScale.z);
    //     rendererTransform.localScale = cachedVector3;

    //     transform.position += direction.normalized * speed * Time.deltaTime;
    // }


}
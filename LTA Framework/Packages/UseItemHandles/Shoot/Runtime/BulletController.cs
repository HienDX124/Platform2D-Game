using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LTA.Move;
using System;

public class BulletController : BaseBulletControlller
{
    MoveController move;
    [SerializeField]
    float timeToDestroy = -1f;
    protected MoveController Move
    {
        get
        {
            if (move == null) move = GetComponent<MoveController>();
            return move;
        }
    }
    [SerializeField]
    float timeCount = 0;
    protected override bool IsDestroy
    {
        get
        {
            return timeToDestroy >= 0f && timeCount > timeToDestroy;
        }
    }


    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        if (timeToDestroy < 0f) return;
        timeCount++;
        if (Move == null) return;
        Move.Move(direction);
        transform.up = direction;
    }

    public override void Shoot(Transform target)
    {
        base.Shoot(target);
        float distance = Vector3.Distance(target.position, transform.position);
        timeToDestroy = (float)(distance / (direction.magnitude * Move.speed * Time.fixedDeltaTime));
        timeToDestroy -= Move.speed *2 *Time.fixedDeltaTime;
    }
}

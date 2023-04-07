using System;
using System.Collections;
using System.Collections.Generic;
using LTA.Move;
using UnityEngine;

public class BulletController : LinearMoveController
{
    private int count = 0;
    private void Update()
    {
        count++;
        Move(transform.right);
        if (count > 600)
        {
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character3DItemController : CharacterItemController
{
    protected override Vector3 Direction {
        set
        {
        //    Vector3 direction = new Vector3(
        //        value.x,
        //        0,
        //        value.z
        //);
            transform.forward = value;
        }
    }
}

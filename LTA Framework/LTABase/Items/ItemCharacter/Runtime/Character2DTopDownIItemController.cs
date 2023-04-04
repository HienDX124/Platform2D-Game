using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character2DTopDownIItemController : CharacterItemController
{
    protected override Vector3 Direction { 
        set {
            transform.up = value;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttacking
{
    void Attacking(Transform target,AttackController attack);
}
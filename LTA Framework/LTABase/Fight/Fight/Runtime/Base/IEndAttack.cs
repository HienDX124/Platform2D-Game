using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEndAttack
{
    void OnEndAttack(Transform target,AttackController attack);
}

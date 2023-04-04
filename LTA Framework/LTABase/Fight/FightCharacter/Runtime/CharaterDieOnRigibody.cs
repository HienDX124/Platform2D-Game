using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaterDieOnRigibody : MonoBehaviour,IOnCharacterDie
{
    Rigidbody _rigidbody;
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }


    public void OnDie()
    {
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.angularDrag = 0;
    }

}

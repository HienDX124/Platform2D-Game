using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterItemRigibodyController : MonoBehaviour,IOnCharacterUserItem
{
    Rigidbody _rigidbody;
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void OnCharacterUserItem(CharacterItemInfo itemInfo)
    {
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.angularDrag = 0;
    }
}

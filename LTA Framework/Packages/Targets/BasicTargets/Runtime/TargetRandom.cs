using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetRandom : MonoBehaviour, ICheckTarget
{
    public bool CheckTarget(Transform target)
    {
        return Random.Range(1, 10000) % 2 == 0;
    }
}

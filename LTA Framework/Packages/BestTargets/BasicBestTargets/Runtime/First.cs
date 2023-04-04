using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class First : MonoBehaviour, ICheckBestTarget
{
    public bool CheckTarget(Transform target1, Transform target2)
    {
        return false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nearest : MonoBehaviour, ICheckBestTarget
{
    public bool CheckTarget(Transform target1, Transform target2)
    {
        float distance1 = Vector3.Distance(transform.position, target1.position);
        float distance2 = Vector3.Distance(transform.position, target2.position);
        return distance1 > distance2;
    }
}

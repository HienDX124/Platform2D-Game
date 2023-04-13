using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingController : MonoBehaviour
{
    protected void Shooting(Transform tranShoot)
    {
        Creator.Instance.CreateBulletPref(tranShoot);
    }
}

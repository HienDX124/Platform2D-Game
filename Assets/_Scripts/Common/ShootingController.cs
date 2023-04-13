using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingController : MonoBehaviour
{
    public void Shooting(Transform tranShoot)
    {
        Creator.Instance.CreateBulletPref(tranShoot);
    }
}

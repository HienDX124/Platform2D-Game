using System.Collections;
using System.Collections.Generic;
using LTA.DesignPattern;
using Unity.Mathematics;
using UnityEngine;

// cái này dùng để tạo all prefab trong game (singleton)
public class CreateController : MonoBehaviour
{
    [SerializeField] private BulletController bulletPref;
    
    public BulletController CreateBulletPref(Transform tranShoot)
    {
        BulletController bullet = Instantiate(bulletPref, tranShoot.position, tranShoot.rotation);
        return bullet;
    }
}

public class Creator : SingletonMonoBehaviour<CreateController>{}

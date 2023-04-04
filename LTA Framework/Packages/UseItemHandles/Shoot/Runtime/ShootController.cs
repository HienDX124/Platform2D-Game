using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LTA.Base.Item;
using LTA.Move;
using System.Reflection;

[System.Serializable]
public class ShootInfo
{
    public string pathBullet;
    public string typeBullet;
    public float speed;
    public PackItem[] items;
}

public class ShootController : BaseUseItemEffect<ShootInfo>
{

    public override void UseItem(Transform target)
    {
        if (target == null) return;
        TranShootPos[] tranShootPoses = GetComponentsInChildren<TranShootPos>();
        Debug.Log("Shoot 0");
        foreach (TranShootPos tranShootInfo in tranShootPoses)
        {
            Debug.Log("Shoot 1");
            GameObject gameObject = new GameObject();
            gameObject.transform.localPosition = tranShootInfo.transform.position;
            gameObject.transform.rotation = transform.rotation;            
            Assembly assembly = Assembly.Load("LTA.Shoot");
            BaseBulletControlller baseBullet = (BaseBulletControlller)gameObject.AddComponent(assembly.GetType(info.typeBullet));
            GameObject prefab = GlobalVO.GetAsset.GetAsset<GameObject>(info.pathBullet);
            Instantiate(prefab, gameObject.transform).transform.localPosition = Vector3.zero;
            gameObject.tag = tag;
            if (baseBullet is BulletController)
            {
                if (tranShootInfo.angleShoot > 0f)
                {
                    ArcMoveController arcMoveController = gameObject.AddComponent<ArcMoveController>();
                    arcMoveController.speed = info.speed;
                    float distance = Vector3.Distance(tranShootInfo.transform.position, target.position);
                    float height = Vector3.up.y * distance * 0.1f;
                    if (height < 0) height = 0;
                    arcMoveController.Height = height;
                }
                else
                {
                    LinearMoveController linearMoveController = gameObject.AddComponent<LinearMoveController>();
                    linearMoveController.speed = info.speed;
                }
            }

            foreach (PackItem item in info.items)
            {
                baseBullet.AddItem(item);
            }
            IShooting[] shootings = GetComponentsInChildren<IShooting>();
            foreach (IShooting shooting in shootings)
            {
                shooting.Shooting(gameObject, target); ;
            }
            baseBullet.Shoot(target);

        }
    }

  
}

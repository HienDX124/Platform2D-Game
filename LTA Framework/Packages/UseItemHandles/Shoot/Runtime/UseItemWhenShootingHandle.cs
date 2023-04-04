using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class UseItemWhenShootingHandle : BaseUseItem, IShooting
{
    public void Shooting(GameObject bullet, Transform target)
    {
        Debug.Log("Shooting");
        OwnUseItem.UseItem(new Transform[1] {bullet.transform});
    }

    public override void UseItem(Transform target)
    {
        
    }
}

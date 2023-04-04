using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TranShootInfo
{
    public Vector3 pos;
    public float angleShoot;
    public TranShootInfo(Vector3 pos,float angleShoot)
    {
        this.pos = pos;
        this.angleShoot = angleShoot;
    }
}

public class TranShootPos : MonoBehaviour
{
    public float angleShoot = 0f;

    public TranShootInfo GetTranShootInfo()
    {
        TranShootInfo info = new TranShootInfo(transform.localPosition,angleShoot);
        Destroy(this.gameObject);
        return info;
    }
}

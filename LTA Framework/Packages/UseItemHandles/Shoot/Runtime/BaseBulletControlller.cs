using UnityEngine;
using LTA.Base.Item;

public abstract class BaseBulletControlller : UseItemsController
{
    protected abstract bool IsDestroy { get; }

    protected virtual void FixedUpdate()
    {
        if (IsDestroy)
        {
            UseItem(new Transform[1] {target});
            Destroy(this.gameObject);
        }
    }

    protected Transform target;

    protected Vector3 direction;

    public virtual void Shoot(Transform target)
    {
        this.target = target;
        direction = target.position - transform.position;
    }
}

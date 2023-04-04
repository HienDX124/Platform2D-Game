using LTA.Base.Item;
using UnityEngine;

[System.Serializable]
public class AttackInfo
{
    public Damage damage;
    public static AttackInfo operator +(AttackInfo a, AttackInfo b)
    {
        AttackInfo attackInfo = new AttackInfo();
        attackInfo.damage = a.damage + b.damage;
        return attackInfo;
    }

    public static AttackInfo operator -(AttackInfo a, AttackInfo b)
    {
        AttackInfo attackInfo = new AttackInfo();
        attackInfo.damage = a.damage - b.damage;
        return attackInfo;
    }

    public static AttackInfo operator *(AttackInfo a, AttackInfo b)
    {
        AttackInfo attackInfo = new AttackInfo();
        attackInfo.damage = a.damage * b.damage;
        return attackInfo;
    }

    public static AttackInfo operator /(AttackInfo a, float b)
    {
        AttackInfo attackInfo = new AttackInfo();
        attackInfo.damage = a.damage / b;
        return attackInfo;
    }
}

public class AttackController : BaseUseItemEffect<AttackInfo>
{
    public override void UseItem(Transform target)
    {
        IAttacking[] attackings = GetComponentsInChildren<IAttacking>();
        foreach (IAttacking attacking in attackings)
        {
            attacking.Attacking(target,this);
        }
        base.UseItem(target);
        IEndAttack[] endAttacks = GetComponentsInChildren<IEndAttack>();
        foreach (IEndAttack endAttack in endAttacks)
        {
            endAttack.OnEndAttack(target,this);
        }
    }
}

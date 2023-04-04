using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Damage
{
    public float critRate = 0;
    public float critDamage = 0;
    public float physicDamage = 0;
    public float magicDamage = 0;
    public float pureDamage = 0;
    public static Damage operator +(Damage a, Damage b)
    {
        Damage Damage = new Damage();
        Damage.critRate = a.critRate + b.critRate;
        Damage.critDamage = a.critDamage + b.critDamage;
        Damage.physicDamage = a.physicDamage + b.physicDamage;
        Damage.magicDamage = a.magicDamage + b.magicDamage;
        Damage.pureDamage = a.pureDamage + b.pureDamage;
        return Damage;
    }

    public static Damage operator -(Damage a, Damage b)
    {
        Damage Damage = new Damage();
        Damage.critRate = a.critRate - b.critRate;
        Damage.critDamage = a.critDamage - b.critDamage;
        Damage.physicDamage = a.physicDamage - b.physicDamage;
        Damage.magicDamage = a.magicDamage - b.magicDamage;
        Damage.pureDamage = a.pureDamage - b.pureDamage;
        return Damage;
    }

    public static Damage operator *(Damage a, Damage b)
    {
        Damage Damage = new Damage();
        Damage.critRate = a.critRate * b.critRate;
        Damage.critDamage = a.critDamage * b.critDamage;
        Damage.physicDamage = a.physicDamage * b.physicDamage;
        Damage.magicDamage = a.magicDamage * b.magicDamage;
        Damage.pureDamage = a.pureDamage * b.pureDamage;
        return Damage;
    }

    public static Damage operator /(Damage a, float b)
    {
        Damage Damage = new Damage();
        Damage.critRate = a.critRate * b;
        Damage.critDamage = a.critDamage * b;
        Damage.physicDamage = a.physicDamage * b;
        Damage.magicDamage = a.magicDamage * b;
        Damage.pureDamage = a.pureDamage * b;
        return Damage;
    }
}
using System.Collections;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using LTA.Base;
using LTA.Base.Item;
[System.Serializable]
public class DefenceInfo
{
        
        public float armor = 0;

        public float magicResistance = 0;

        public float HP = 0;

        public static DefenceInfo operator +(DefenceInfo a, DefenceInfo b)
        {
            DefenceInfo entity = new DefenceInfo();
            entity.armor = a.armor + b.armor;
            entity.HP = a.HP + b.HP;
            entity.magicResistance = a.magicResistance + b.magicResistance;
            return entity;
        }

        public static DefenceInfo operator -(DefenceInfo a, DefenceInfo b)
        {
            DefenceInfo entity = new DefenceInfo();
            entity.armor = a.armor - b.armor;
            entity.HP = a.HP - b.HP;
            entity.magicResistance = a.magicResistance - b.magicResistance;
            return entity;
        }

        public static DefenceInfo operator *(DefenceInfo a, DefenceInfo b)
        {
            DefenceInfo entity = new DefenceInfo();
            entity.armor = a.armor * b.armor;
            entity.HP = a.HP * b.HP;
            entity.magicResistance = a.magicResistance * b.magicResistance;
            return entity;
        }

        public static DefenceInfo operator /(DefenceInfo a, float b)
        {

            DefenceInfo entity = new DefenceInfo();
            if (b == 0) return entity;
            entity.armor = (float)a.armor / b;
            entity.HP = (float)a.HP / b;
            entity.magicResistance = (float)a.magicResistance / b;
            return entity;
        }
}
[RequireComponent(typeof(BeUseItemController))]
public class DefenceController : BaseOnBeUseItemController,IOnUpLevel
{
    public HPController hpController;

    DefenceInfo info;

    public DefenceInfo Info
    {
        set
        {
            info = value;
            hpController.SetHP(info.HP);
        }
    }
    protected void Awake()
    {
        Main.AddOnBeUseItemHandle<AttackInfo>(this);
        hpController = GetComponentInChildren<HPController>();
        hpController.Die = OnDie;
    }

    public override void OnBeUseItem(object itemInfo)
    {
        AttackInfo fightInfo = (AttackInfo)itemInfo;
        
        Damage damage = fightInfo.damage;
        float physicDamage = damage.physicDamage;
        float magicDamage = damage.magicDamage;
        float pureDamage = damage.pureDamage;

        physicDamage *= 100 / (100 + info.armor);

        magicDamage *= 100 / (100 + info.magicResistance);

        CritDamage(ref physicDamage, damage);
        CritDamage(ref magicDamage, damage);
        CritDamage(ref pureDamage, damage);

        float realDamage = physicDamage + magicDamage + pureDamage;

        hpController.TakeDamage(realDamage);
    }
    void CritDamage(ref float damage, in Damage info)
    {
        float crit = Random.Range(1f, 100f);
        if (crit <= info.critRate)
        {
            damage *= (float)info.critDamage / 100;
        }
    }

    void OnDie()
    {
        IOnDie[] onDies = GetComponentsInChildren<IOnDie>();
        Debug.Log("hp "+ hpController.HP);
        if (onDies != null && onDies.Length > 0)
        {
            foreach (IOnDie onDie in onDies)
            {
                onDie.OnDie(); 
                
            }
            return;
        }
        Destroy(gameObject);
    }

    public void OnUpLevel(int level)
    {
        Info = FightDataController.Instance.defenceVO.GetData<DefenceInfo>(name, level);
    }
}



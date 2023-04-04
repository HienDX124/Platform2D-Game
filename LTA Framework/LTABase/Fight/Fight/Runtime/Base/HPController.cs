using UnityEngine;
using LTA.Base;
using System;
public class HPController : ProcessController
{
    Action die;

    public Action Die
    {
        set
        {
            die = value;
        }
        get
        {
            return die;
        }
    }

    public float CurrentHP
    {
        get
        {
            return currentValue;
        }
        set
        {
            EditValue(value);
        }
    }

    public float HP
    {
        get
        {
            return maxValue;
        }
    }

    public void SetHP(float HP)
    {
        maxValue = HP;
        SetValue(maxValue);
    }
    
    public void EditHP(float HP, Action OnCompleteProcessing = null)
    {
        maxValue = HP;
        EditValue(maxValue, OnCompleteProcessing);
    }
    
    public void TakeDamage(float damage)
    {
        EditValue(currentValue - damage);
    }

    public void Heal(float heal)
    {
        EditValue(currentValue + heal);
    }

    public void ResetHP()
    {
        SetValue(maxValue);
    }

    protected override void OnUpdate(float value)
    {
        transform.localScale = new Vector3((float)value / maxValue, transform.localScale.y, 1);
        if (value == 0)
        {
            if (die != null)
            {
                Debug.Log("HP Die");
                die();
                die = null;
            }
        }
    }
}
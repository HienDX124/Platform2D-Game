using System;
using UnityEngine;
using LTA.Condition;
[System.Serializable]
public class CountDownInfo
{
    public float timeCountDown;

    public bool fistValue = false;

    public CountDownInfo(float time)
    {
        timeCountDown = time;
    }
}

public class CountDownCondition : BaseConditionEffect<CountDownInfo>,IResetCondition
{
    public float countDown = 0;

    public override object Info
    {
        set
        {
            countDown = ((CountDownInfo)value).timeCountDown;
            Debug.Log("countDown" + countDown);
            base.Info = value;
            isSuitable = EffectInfo.fistValue;
            if (isSuitable)
                OnSuitableCondition(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (EffectInfo == null) return;
        if (countDown >= 0)
        {
            countDown -= Time.deltaTime;
            return;
        }
        OnSuitableCondition(true);
    }

    public void ResetCondition()
    {
        countDown = EffectInfo.timeCountDown;
        isSuitable = false;
    }
}

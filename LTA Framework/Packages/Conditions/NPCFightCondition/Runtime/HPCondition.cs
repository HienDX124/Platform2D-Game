using System;
using System.Collections.Generic;
using LTA.Base.Item;
using LTA.Condition;
using UnityEngine;

public class TypeCheckHP
{
    public const string BIGGER = "Bigger";
    public const string SMALLER = "Smaller";
    public const string EQUAL = "Equal";
    public const string BIGGER_OR_EQUAL = "BiggerOrEqual";
    public const string SMALLER_OR_EQUAL = "SmallerOrEqual";
}

[System.Serializable]
public class HPConditionInfo
{
    public string itemName;
    public string typeCheck;
}

public class HPCondition : BaseConditionEffect<HPConditionInfo>, IOnNPCGetTarget
    {
        HPController hpController;

        HPController HPController
        {
            get
            {
                if (hpController == null) hpController = GetComponentInChildren<HPController>();
                return hpController;
            }
        }
        
        public void OnNPCGetTarget(PackItem packItem, List<Transform> targets, int numTarget)
        {
            if (packItem.itemName != info.itemName) return;
            if (targets.Count == 0)
            {
                OnSuitableCondition(true);
                return;
            }
            foreach (Transform target in targets)
            {
                if(target == null) continue;
                HPController controller = target.GetComponentInChildren<HPController>();
                if (controller == null) continue;
                switch(info.typeCheck)
                {
                    case TypeCheckHP.BIGGER:
                        if (controller.CurrentHP >= HPController.CurrentHP)
                        {
                            OnSuitableCondition(false);
                            return;
                        }
                        break;
                    case TypeCheckHP.SMALLER:
                        if (controller.CurrentHP <= HPController.CurrentHP)
                        {
                            OnSuitableCondition(false);
                            return;
                        }
                        break;
                    case TypeCheckHP.SMALLER_OR_EQUAL:
                        if (controller.CurrentHP < HPController.CurrentHP)
                        {
                            OnSuitableCondition(false);
                            return;
                        }
                        break;
                    case TypeCheckHP.BIGGER_OR_EQUAL:
                        if (controller.CurrentHP > HPController.CurrentHP)
                        {
                            OnSuitableCondition(false);
                            return;
                        }
                        break;
                case TypeCheckHP.EQUAL:
                        if (controller.CurrentHP != HPController.CurrentHP)
                        {
                            OnSuitableCondition(false);
                            return;
                        }
                        break;
                }
            }
            OnSuitableCondition(true);
        }
}
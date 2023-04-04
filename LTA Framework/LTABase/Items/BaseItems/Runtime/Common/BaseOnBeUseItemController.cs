using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LTA.Condition;
namespace LTA.Base.Item
{
    public abstract class BaseOnBeUseItemController : BaseMainComponent<BeUseItemController>, IOnBeUseItem
    {
        protected ICondition[] conditions;

        public bool IsAllowBeUseItem {
            get {
                if (conditions == null) return true;
                foreach (ICondition condition in conditions)
                {
                    if (!condition.IsSuitable) return false;
                }
                return true;
            }
        }

        public abstract void OnBeUseItem(object info);
    }
}

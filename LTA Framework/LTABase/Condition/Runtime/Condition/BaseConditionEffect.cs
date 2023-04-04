using LTA.Base;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace LTA.Condition
{
    public class BaseConditionEffect<T> : BaseCondition,ISetInfo
    {
        protected T info;

        public virtual object Info
        {
            set
            {
                info = (T)value;
            }
        }

        public T EffectInfo
        {
            get
            {
                return info;
            }
        }

    }
}

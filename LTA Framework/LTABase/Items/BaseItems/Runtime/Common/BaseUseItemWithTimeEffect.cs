using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace LTA.Base.Item
{
    [System.Serializable]
    public class TimeEffectInfo
    {
        public float timeEffect;
    }

    public class BaseUseItemWithTimeEffect<T> : BaseUseItemEffect<T> where T : TimeEffectInfo
    {
        float timeEffect;
        [SerializeField]
        private float timeAffect;

        bool isActive = false;

        protected bool IsActive
        {
            get
            {
                return isActive;
            }
            set
            {
                isActive = value;
            }
        }

        public override object Info
        {
            set
            {
                base.Info = value;
                timeAffect = ItemInfo.timeEffect;
                timeEffect = ItemInfo.timeEffect;
                isActive = false;
            }
        }

        void Update()
        {
            if (!isActive) return;
            if (timeAffect <= 0) return;
            timeAffect -= Time.deltaTime;
            if (timeAffect <= 0)
            {
                ResetTime();
            }
        }

        public virtual void ResetTime()
        {
            isActive = false;
            timeAffect = timeEffect;
        }
    }
}

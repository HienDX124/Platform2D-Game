using UnityEngine;

namespace LTA.Base.Item
{
    public abstract class BaseUseItemEffect<T> : BaseUseItem,ISetInfo
    {
        [SerializeField]
        protected T info;

        public virtual object Info
        {
            set
            {
                info = (T)value;
            }
        }

        public T ItemInfo
        {
            get
            {
                return info;
            }
            set
            {
                info = value;
            }
        }
        public override void UseItem(Transform target)
        {
            if (target == null) return;

            BeUseItemController beUseItemController = target.GetComponent<BeUseItemController>();
            if (beUseItemController == null)
            {
                //Debug.Log("name target : "+ target.name);
                return;
            }
            beUseItemController.Handle(info);
        }


    }
}

using System.Collections.Generic;
using UnityEngine;
using LTA.Condition;
using LTA.VO;
using System;
using System.Reflection;

namespace LTA.Base.Item
{
    [System.Serializable]
    public class ItemInfo
    {
        public SubInfo[] bestTargets;
        public SubInfo[] targets;
        public SubInfo[] conditions;
        public SubInfo[] useItemHandles;
    }
    [System.Serializable]
    public class PackItem
    {
        public string itemName;
        public int level;

        public PackItem(string name,int level)
        {
            this.itemName = name;
            this.level = level;
        }
    }

    public class UseItemController : FilterTargetController
    {
        ItemInfo info;
        protected List<ICondition> conditions = new List<ICondition>();
        protected List<IResetCondition> resetConditions = new List<IResetCondition>();
        protected List<IUseItem> useItems = new List<IUseItem>();

        public PackItem packItem;

        public List<ICondition> Conditions
        {
            get
            {
                 return conditions;
            }
        }

        public virtual ItemInfo ItemInfo
        {
            set
            {
                Clear();
                info = value;

                if (value.bestTargets != null)
                {
                    UtilsVO.AddSubInfos(gameObject, value.bestTargets, (effectBestTarget) =>
                    {
                        ICheckBestTarget bestTarget = (ICheckBestTarget)effectBestTarget;
                        bestTargets.Add(bestTarget);
                    });
                }

                if (value.targets != null)
                {
                    UtilsVO.AddSubInfos(gameObject,value.targets, (effectTarget) =>
                    {
                        ICheckTarget target = (ICheckTarget)effectTarget;
                        targets.Add(target);
                    });
                }
                if (value.conditions != null)
                {
                    UtilsVO.AddSubInfos(gameObject,value.conditions, (effectCondition) =>
                    {
                        ICondition condition = (ICondition)effectCondition;
                        conditions.Add(condition);
                        if (effectCondition is IResetCondition)
                        {
                            resetConditions.Add((IResetCondition)effectCondition);
                        }
                    });
                }
                if (value.useItemHandles != null)
                {
                    UtilsVO.AddSubInfos(gameObject,value.useItemHandles, (effectUseItem) =>
                    {
                        IUseItem useItem = (IUseItem)effectUseItem;
                        useItem.OwnUseItem = this;
                        useItems.Add(useItem);
                    });
                }
                IAddItemInfo[] addItemInfos = GetComponentsInChildren<IAddItemInfo>();
                foreach (IAddItemInfo addItemInfo in addItemInfos)
                {
                    addItemInfo.OnAddItemInfo(info);
                }
            }
            get
            {
                return info;
            }
        }

        bool isUseingItem = false;

        public virtual void UseItem(Transform[] targets)
        {
            if (targets.Length == 0) return;
            if (!IsAllowUseItem) return;
            if (useItems == null) return;
            if (isUseingItem) return;
            isUseingItem = true;
            ResetCondition();
            foreach (IUseItem useItem in useItems)
            {
                useItem.UseItem(targets);
            }
            foreach (Transform target in targets)
            {
                if (target == null) continue;
                IBeUseItem[] beUseItems = target.GetComponents<IBeUseItem>();
                foreach (IBeUseItem beUseItem in beUseItems)
                {
                    beUseItem.OnBeUseItem(packItem);
                }
            }
            IOnUseItem[] onUseItems = GetComponentsInChildren<IOnUseItem>();
            foreach(IOnUseItem onUseItem in onUseItems)
            {
                onUseItem.OnUseItem(packItem);
            }
            isUseingItem = false;
        }

        public void ResetCondition()
        {
            foreach (IResetCondition resetCondition in resetConditions)
            {
                resetCondition.ResetCondition();
            }
        }

        public bool IsAllowUseItem
        {
            get
            {
                foreach (ICondition condition in conditions)
                {
                    if (!condition.IsSuitable)
                        return false;
                }
                return true;
            }
        }

        void Clear()
        {
            foreach (ICheckBestTarget checkBestTarget in bestTargets)
            {
                Destroy((MonoBehaviour)checkBestTarget);
            }
            bestTargets.Clear();

            foreach (ICheckTarget target in targets)
            {
                Destroy((MonoBehaviour)target);
            }
            targets.Clear();
            foreach (ICondition condition in conditions)
            {
                Destroy((MonoBehaviour)condition);
            }
            conditions.Clear();
            resetConditions.Clear();
            foreach (IUseItem useItem in useItems)
            {
                MonoBehaviour monoUseItem = (MonoBehaviour)useItem;
                IOnRemoveUseItem onRemoveUseItem = monoUseItem.GetComponent<IOnRemoveUseItem>();
                if (onRemoveUseItem != null) onRemoveUseItem.OnRemoveItem();
                Destroy(monoUseItem);
            }
            useItems.Clear();
        }

        private void OnDestroy()
        {
            Clear();
        }
    }
}

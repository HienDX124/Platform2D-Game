using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace LTA.Base.Item
{
    public class BeUseItemController : MonoBehaviour
    {
        Dictionary<string, List<IOnBeUseItem>> dic_typeInfo_OnBeUseItem = new Dictionary<string, List<IOnBeUseItem>>();

        public void AddOnBeUseItemHandle<T>(IOnBeUseItem onBeUseItem)
        {
            string typeInfo = typeof(T).Name;
            if (!dic_typeInfo_OnBeUseItem.ContainsKey(typeInfo))
            {
                dic_typeInfo_OnBeUseItem.Add(typeInfo, new List<IOnBeUseItem>());
            }
            List<IOnBeUseItem> onBeUseItems = dic_typeInfo_OnBeUseItem[typeInfo];
            onBeUseItems.Add(onBeUseItem);
        }

        public void RemoveOnBeUseItemHandle<T>(IOnBeUseItem onBeUseItem)
        {
            string typeInfo = typeof(T).Name;
            if (!dic_typeInfo_OnBeUseItem.ContainsKey(typeInfo)) return;
            List<IOnBeUseItem> onBeUseItems = dic_typeInfo_OnBeUseItem[typeInfo];
            if (!onBeUseItems.Contains(onBeUseItem)) return;
            onBeUseItems.Remove(onBeUseItem);
        }

        public void Handle(object info)
        {
            string typeInfo = info.GetType().Name;
            if (!dic_typeInfo_OnBeUseItem.ContainsKey(typeInfo)) return;
            List<IOnBeUseItem> onBeUseItems = dic_typeInfo_OnBeUseItem[typeInfo];
            foreach(IOnBeUseItem onBeUseItem in onBeUseItems)
            {
                if (onBeUseItem.IsAllowBeUseItem)
                    onBeUseItem.OnBeUseItem(info);
            }
        }
    }
}

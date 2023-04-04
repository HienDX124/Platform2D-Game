using System.Collections.Generic;
using UnityEngine;

namespace LTA.Base.Item
{
    public class UseItemsController : MonoBehaviour, IOnUpLevel
    {
        Dictionary<string, UseItemController> dic_itemName_useItem = new Dictionary<string, UseItemController>();
        List<PackItem> packItems = new List<PackItem>();
        private IOnRemoveAllItem[] onRemoveAllItem;

        public int ItemCount
        {
            get
            {
                return packItems.Count;
            }
        }

        public PackItem GetItem(string itemName)
        {
            foreach (PackItem packItem in packItems)
            {
                if (packItem.itemName == itemName)
                {
                    return packItem;
                }
            }
            return null;
        }

        public PackItem GetItem(PackItem checkPackItem)
        {
            foreach (PackItem packItem in packItems)
            {
                if (packItem == checkPackItem)
                {
                    return packItem;
                }
            }
            return null;
        }

        public IOnRemoveAllItem[] OnRemoveAllItem
        {
            get
            {
                if (onRemoveAllItem == null) onRemoveAllItem = GetComponents<IOnRemoveAllItem>();
                return onRemoveAllItem;
            }
        }

        public UseItemController AddItem(PackItem item,int index)
        {
            if (!ItemDataController.Instance.baseItemVO.CheckKey(item.itemName)) return null;
            ItemInfo itemInfo = ItemDataController.Instance.baseItemVO.GetItemInfo(item.itemName, item.level);
            if (itemInfo == null) return null;
            PackItem packItem = packItems[index];

            if (dic_itemName_useItem.ContainsKey(packItem.itemName))
            {
                UseItemController oldUseItem = dic_itemName_useItem[packItem.itemName];
                dic_itemName_useItem.Remove(packItem.itemName);
                Destroy(oldUseItem);
            }

            UseItemController useItem;
            if (!dic_itemName_useItem.ContainsKey(item.itemName))
            {
                useItem = gameObject.AddComponent<UseItemController>();
                dic_itemName_useItem.Add(item.itemName, useItem);
                packItems[index] = item;
            }
            else
            {
                useItem = dic_itemName_useItem[item.itemName];
                item = packItems[index];
            }
            useItem.packItem = item;
            useItem.ItemInfo = itemInfo;
            IAddItemsInfo[] addItemsInfos = GetComponentsInChildren<IAddItemsInfo>();
            foreach (IAddItemsInfo addItemsInfo in addItemsInfos)
            {
                addItemsInfo.OnAddItemsInfo(dic_itemName_useItem.Count, item, useItem);
            }
            return useItem;

        }

        public UseItemController AddItem(PackItem item)
        {
            if (!ItemDataController.Instance.baseItemVO.CheckKey(item.itemName)) return null;
            ItemInfo itemInfo = ItemDataController.Instance.baseItemVO.GetItemInfo(item.itemName, item.level);
            if (itemInfo == null) return null;
            UseItemController useItem;
            if (!dic_itemName_useItem.ContainsKey(item.itemName))
            {
                useItem = gameObject.AddComponent<UseItemController>();
                dic_itemName_useItem.Add(item.itemName, useItem);
                packItems.Add(item);
            }
            else
            {
                useItem = dic_itemName_useItem[item.itemName];
            }
            useItem.packItem = item;
            useItem.ItemInfo = itemInfo;
            IAddItemsInfo[] addItemsInfos = GetComponentsInChildren<IAddItemsInfo>();
            foreach (IAddItemsInfo addItemsInfo in addItemsInfos)
            {
                addItemsInfo.OnAddItemsInfo(dic_itemName_useItem.Count, item, useItem);
            }
            return useItem;
            
        }

        public void RemoveItem(UseItemController useItem)
        {
            packItems.Remove(GetItem(useItem.packItem));
            dic_itemName_useItem.Remove(useItem.packItem.itemName);
            Destroy(useItem);
        }

        public void RemoveItem(string itemName)
        {
            if (!dic_itemName_useItem.ContainsKey(itemName)) return;
            packItems.Remove(GetItem(itemName));
            Destroy(dic_itemName_useItem[itemName]);
            dic_itemName_useItem.Remove(itemName);
        }

        public void RemoveItem()
        {
            if (OnRemoveAllItem != null)
            {
                foreach (IOnRemoveAllItem item in OnRemoveAllItem)
                {
                    item.OnRemoveAll();
                }
            }

            foreach (KeyValuePair<string, UseItemController> itemName_useItem in dic_itemName_useItem)
            {
                Destroy(itemName_useItem.Value);
            }
            packItems.Clear();
            dic_itemName_useItem.Clear();
        }

        public void UseItem(string itemName, Transform[] targets)
        {
            if (!dic_itemName_useItem.ContainsKey(itemName)) return;
            dic_itemName_useItem[itemName].UseItem(targets);
        }

        public void UseItem(Transform[] targets)
        {
            foreach(KeyValuePair<string,UseItemController> itemName_useItem in dic_itemName_useItem)
            {
                itemName_useItem.Value.UseItem(targets);
            }
        }

        public bool IsAllowUseItem(string itemName)
        {
            if (!dic_itemName_useItem.ContainsKey(itemName)) return false;
            return dic_itemName_useItem[itemName].IsAllowUseItem;
        }

        public void OnUpLevel(int level)
        {
            if (!ItemDataController.Instance.useItemsVO.CheckKey(name)) return;
            RemoveItem();
            UseItemsInfo useItemsInfo  = ItemDataController.Instance.useItemsVO.GetData<UseItemsInfo>(name, level);
            if (useItemsInfo == null) return;
            PackItem[] items = useItemsInfo.items;
            for (int i = 0; i < items.Length;i++)
            {
                PackItem item = items[i];
                UseItemController useItem = AddItem(item); 
                
            }
            IEndAddItemsInfo[] endItemsInfos = GetComponentsInChildren<IEndAddItemsInfo>();
            if (endItemsInfos == null) return;
            foreach (IEndAddItemsInfo endItemsInfo in endItemsInfos)
            {
                endItemsInfo.OnEndAddItems();
            }
        }
        

    }
}

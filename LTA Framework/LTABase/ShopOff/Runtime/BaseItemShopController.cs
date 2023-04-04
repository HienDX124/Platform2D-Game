using System;
using System.Collections;
using System.Collections.Generic;
using LTA.DesignPattern;
using UnityEngine;

namespace  ShopCoin
{
    public class BaseItemShopController : MonoBehaviour
    {
        [SerializeField] private RectTransform content;

        [SerializeField] private GameObject item;

        protected float SizeItem;

        private List<BaseItemShop> itemShops = new List<BaseItemShop>();
        protected virtual void  Start()
        {
            Observer.Instance.AddObserver(KeyShop.UPDATE_SHOP_DATA, OnUpdateData);
        }


        public virtual void OnUpdateData(object data)
        {
            if(data == null) return;
            OnClearView(itemShops);
            List<Item> dataShop = (List<Item>)data;
            for (int i = 0; i < dataShop.Count; i++)
            {
                BaseItemShop itemShop = OnCreateItem(content);
                itemShop.OnSetup(dataShop[i],OnClickHandler);
                itemShops.Add(itemShop);
            }

            ResetView(SizeItem, dataShop.Count,content);
        }

        protected virtual void ResetView(float heightItem , int numItem , RectTransform rectContent)
        {
            
        }

        protected virtual void OnClickHandler(object data)
        {
            OnRefreshUI(itemShops , (BaseItemShop)data);
        }

        protected virtual void OnClearView(List<BaseItemShop> data)
        {
            for (int i = 0; i < data.Count; i++)
            {
                if(data[i].gameObject != null)
                    Destroy(data[i].gameObject);
            }
            data.Clear();
        }

        protected virtual void OnRefreshUI(List<BaseItemShop> data ,  BaseItemShop objectCallback)
        {
            
        }
        

        protected void OnDestroy()
        {
            Observer.Instance.RemoveObserver(KeyShop.UPDATE_SHOP_DATA, OnUpdateData);
        }

        #region create item

        private BaseItemShop OnCreateItem(Transform parent)
        {
            GameObject gameObject = Instantiate(item);
            gameObject.transform.SetParent(parent);
            gameObject.transform.localScale = Vector3.one;
            return gameObject.GetComponentInChildren<BaseItemShop>();
        }
        
        #endregion
    }   
}

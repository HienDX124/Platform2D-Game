using System;
using System.Collections;
using System.Collections.Generic;
using LTA.Base.Item;
using LTA.UI;
using ShopCoin;
using UnityEngine;
using UnityEngine.UI;
public class BaseItemShop : BaseInformationController
{
    [SerializeField] private ButtonController btnItem;

    [SerializeField] private AvatarController avatarController;

    protected Item DataSet;

    private Action<object> onClickHandler;

    private void Start()
    {
        btnItem.OnClick(OnClickHandler);
    }

    public virtual void OnSetup(object data ,Action<object> dataCallback)
    {
        OnClearView();
        this.onClickHandler = dataCallback;
        this.DataSet = (Item)data;
        //this.OnUpLevel(DataSet.level);
        avatarController.name = DataSet.itemName;
        avatarController.OnUpLevel(DataSet.level);
    }

    public Item GetDataSet() => this.DataSet;

    protected virtual void OnClearView(){}
    

    protected virtual void OnClickHandler(ButtonController callback)
    {
        if (onClickHandler != null)
            onClickHandler(this);
    }
    
}

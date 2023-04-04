using System.Collections;
using System.Collections.Generic;
using LTA.Base.Item;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class ItemRanking
{
    [SerializeField] protected TextMeshProUGUI txtName;
    [SerializeField] protected TextMeshProUGUI txtLevel;
    [SerializeField] protected TextMeshProUGUI txtPoint;

    protected PackItem dataRemoteLoad;

    //public virtual void OnSetup(PackItem packItemData)
    //{
    //    txtName.text = packItemData.id;
    //    txtLevel.text = "Level "+  packItemData.level.ToString();
    //    txtPoint.text = "Point " + packItemData.exp;

    //}

    //public override void OnUpLevel(int level)
    //{
    //    base.OnUpLevel(level);
    //    if (this.txtName != null) txtName.text = name;
    //}

    //public void OnShow(bool value)
    //{
    //    gameObject.SetActive(value);
    //}
}

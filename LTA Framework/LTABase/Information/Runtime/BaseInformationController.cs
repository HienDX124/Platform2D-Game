using System;
using System.Collections;
using System.Collections.Generic;
using LTA.Base.Item;
using UnityEngine;

public class BaseInformationController : MonoBehaviour, IOnUpLevel
{
    [SerializeField] private string type;
    [SerializeField] private TextInformation[] lstTextInformation;
    
    private string[] infoType = {"Title","Price","Tiers"};
    
    protected ItemInfo ItemInfo;
    
    protected virtual void OnSetInformation(List<TextInfor> dataInformation)
    {
        if(dataInformation == null) return;
        for (int i = 0; i < dataInformation.Count; i++)
        {
            TextInfor info = (TextInfor)dataInformation[i];
            TextInformation inforSet = GetTxtInformationByType(info.type);
            if(inforSet == null) continue;
            inforSet.OnSetInformation(info.value);
        }
    }

    private TextInformation GetTxtInformationByType(string type)
    {
        for (int i = 0; i < lstTextInformation.Length; i++)
        {
            if (ContentTextInformation(type,lstTextInformation[i]))
                return lstTextInformation[i];
        }
        return null;
    }

    private bool ContentTextInformation(string type , TextInformation objectCheck)
    {
        return type == infoType[(int)objectCheck.GetType()];
    }


    public void OnUpLevel(int level)
    {
        // TextInfor[] dataInformation = InformationController.Instance.getInformationVo(type).GetData<TextInfor[]>(name,level);
        List<TextInfor> dataInformation = InformationController.Instance.getInformationVo(type).GetDatas<TextInfor>(name);
        OnSetInformation(dataInformation);
    }
}

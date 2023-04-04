using System;
using System.Collections;
using System.Collections.Generic;
using LTA.DesignPattern;
using UnityEngine;

public class InformationController : Singleton<InformationController>
{
    Dictionary<string, InformationVo> dic_Name_InformationVO = new Dictionary<string, InformationVo>();

    public InformationVo getInformationVo(string dataName)
    {
        if (!dic_Name_InformationVO.ContainsKey(dataName)) throw new Exception(dataName + " is null");
        return dic_Name_InformationVO[dataName];
    }

    public void LoadLocalData(string dataName)
    {
        if (dic_Name_InformationVO.ContainsKey(dataName)) return;
        dic_Name_InformationVO.Add(dataName, new InformationVo(dataName));
    }
}


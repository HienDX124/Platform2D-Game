using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LTA.VO;
using SimpleJSON;
using System;

public class CharactersVO : BaseMutilVO
{
    public CharactersVO()
    {
        LoadData<BaseVO>("Entities", "characterInfo");
    }

    public string GetAnimName(string type,int level,string state)
    {
        JSONObject json = GetData(type, level);
        return json[state];
    }
}

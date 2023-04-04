using System;
using System.Collections;
using System.Collections.Generic;
using LTA.VO;
using UnityEngine;

public class InformationVo : BaseMutilVO
{
    public InformationVo(string data)
    {
        LoadData<BaseVO>(data,"information");
    }
}

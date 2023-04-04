using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LTA.VO;
using System;

public class DefenceVO : BaseMutilVO
{
    public DefenceVO()
    {
        LoadData<BaseVO>("Entities", "defenceInfo");
    }
}

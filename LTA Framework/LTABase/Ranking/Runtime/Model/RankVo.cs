using System;
using System.Collections;
using System.Collections.Generic;
using LTA.VO;
using UnityEngine;

public class RankVo : BaseMutilVO
{
    public RankVo()
    {
        LoadData<BaseVO>("Items","rankingInfo");
    }

}

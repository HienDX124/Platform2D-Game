using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LTA.VO;
using System;

public class ReciveItemsVO : BaseMutilVO
{
    public ReciveItemsVO()
    {
        LoadData<BaseVO>("Entities", "reciveItems");
    }
}

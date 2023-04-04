using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LTA.VO;
using System;

public class ItemOfCharacterVO : BaseMutilVO
{
    public ItemOfCharacterVO()
    {
        LoadData<BaseVO>("Items", "characterItemInfo");
    }
}

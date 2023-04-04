using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LTA.DesignPattern;
using System;

public class ItemCharacterDataController : Singleton<ItemCharacterDataController>
{
    public ItemOfCharacterVO itemOfCharacterVO;
    public void LoadDataLocal()
    {
        itemOfCharacterVO = new ItemOfCharacterVO();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LTA.DesignPattern;
using System;

public class ListItemsDataController : Singleton<ListItemsDataController>
{
    public ReciveItemsVO reciveItemsVO;

    public void LoadDataLocal()
    {
        reciveItemsVO = new ReciveItemsVO();
    }
}

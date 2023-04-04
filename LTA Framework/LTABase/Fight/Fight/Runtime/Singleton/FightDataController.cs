using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LTA.DesignPattern;
using System;

public class FightDataController : Singleton<FightDataController>
{
    public DefenceVO defenceVO;

    public void LoadLocalData()
    {
        defenceVO = new DefenceVO();
    }
}

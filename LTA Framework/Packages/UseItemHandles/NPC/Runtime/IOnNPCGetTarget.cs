using LTA.Base.Item;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IOnNPCGetTarget
{
    void OnNPCGetTarget(PackItem packItem,List<Transform> targets,int numTarget);
}

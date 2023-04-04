using System.Collections;
using System.Collections.Generic;
using LTA.Base.Item;
using LTA.DesignPattern;
using Sfs2X.Entities.Data;
using UnityEngine;

public class SmartFoxItemsExp : SmartFoxEntities
{
    public SmartFoxItemsExp(string listEntitiesName) : base(listEntitiesName)
    {
        
    }

    public override void OnResponse(ISFSObject data)
    {
        if (ListUtils<PackItem>.dic_Name_ListObj.ContainsKey(listEntitiesName))
        {
            ListUtils<PackItem>.dic_Name_ListObj[listEntitiesName].Clear();
        }
        ISFSArray items = data.GetSFSArray("Entities");
        for (int i = 0; i < items.Count; i++)
        {
            ISFSObject item = items.GetSFSObject(i);
            //AddEntity(new PackItem(item.GetUtfString("fighterId"),item.GetInt("exp"), 
            //    item.GetUtfString("EntityName"),item.GetInt("level")));
        }
        Debug.Log("on respone : "+ listEntitiesName);
        Observer.Instance.Notify(listEntitiesName, ListUtils<PackItem>.dic_Name_ListObj[listEntitiesName]);
    }

    protected override void AddEntity(string entityName, int level)
    {
        
    }

    private void AddEntity(PackItem packFighter ) 
    {
        ListUtils<PackItem>.AddObjRespond(listEntitiesName, packFighter);
    }
}
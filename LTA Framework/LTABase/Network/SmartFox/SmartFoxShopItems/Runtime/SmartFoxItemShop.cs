using System.Collections;
using System.Collections.Generic;
using LTA.Base.Item;
using LTA.DesignPattern;
using LTA.SFS.Base;
using Sfs2X.Entities.Data;
using UnityEngine;

public class SmartFoxItemShop : SmartFoxEntities
{
    public SmartFoxItemShop(string listEntitiesName) : base(listEntitiesName)
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
            if (item.GetUtfString("type") == "random")
            {
                Debug.Log("item random");
                    
            }
            AddEntity(item.GetUtfString("itemId"),item.GetUtfString("baseId"),"",item.GetInt("level"),item.GetInt("price"),item.GetUtfString("type"));
        }
        Observer.Instance.Notify(listEntitiesName, ListUtils<PackItem>.dic_Name_ListObj[listEntitiesName]);
    }

    protected override void AddEntity(string entityName, int level)
    {
        
    }
    private void AddEntity(string itemId,string id,string entityName, int level, int price, string type)
    {
        ListUtils<PackItem>.AddObjRespond(listEntitiesName, new PackItemShop(itemId,id,entityName,level,price,type));
    }
}

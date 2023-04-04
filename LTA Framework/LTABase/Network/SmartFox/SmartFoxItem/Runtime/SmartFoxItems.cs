using System.Linq;
using LTA.Base.Item;
using LTA.DesignPattern;
using LTA.SFS.Base;
using Sfs2X.Entities.Data;
using UnityEngine;

public class SmartFoxItems : SmartFoxEntities
{
    public SmartFoxItems(string listEntitiesName) : base(listEntitiesName)
    {
    }

    public override void OnResponse(ISFSObject data)
    {
        if (ListUtils<PackItem>.dic_Name_ListObj.ContainsKey(listEntitiesName))
        {
            ListUtils<PackItem>.dic_Name_ListObj[listEntitiesName].Clear();
        }
        ISFSArray materials = data.GetSFSArray("Entities");
        for (int i = 0; i < materials.Count; i++)
        {
            ISFSObject material = materials.GetSFSObject(i);
            AddEntity(material.GetUtfString("itemId"),material.GetInt("level"));
        }
        Debug.Log("on respone : "+ listEntitiesName);
        Observer.Instance.Notify(listEntitiesName, ListUtils<PackItem>.dic_Name_ListObj[listEntitiesName]);
    }

    protected override void AddEntity(string entityName, int level)
    {
        ListUtils<PackItem>.AddObjRespond(listEntitiesName, new PackItem(entityName, level));
    }
}

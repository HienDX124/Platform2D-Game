using System.Collections;
using System.Collections.Generic;
using System.Linq;
using LTA.DesignPattern;
using Sfs2X.Entities.Data;
using UnityEngine;

public class SmartFoxExp : SmartFoxEntities
{
    public SmartFoxExp(string listEntitiesName) : base(listEntitiesName)
    {
        
    }

    public override void OnResponse(ISFSObject data)
    {
        //if (ListFighterVar.dic_name_list_fighter.ContainsKey(listEntitiesName))
        //{
        //    ListFighterVar.dic_name_list_fighter[listEntitiesName].Clear();
        //    ListFighterVar.dic_name_list_fighter.Remove(listEntitiesName);
        //}
            
        //ISFSArray items = data.GetSFSArray("Entities");
        //List<PackFighter> lstPack = new List<PackFighter>();
        //for(int i = 0;i < items.Count;i++)
        //{
        //    List<PackItem> pack = new List<PackItem>();
        //    ISFSObject item = items.GetSFSObject(i);
        //    if (item.ContainsKey("items"))
        //    {
        //        ISFSArray packItems = item.GetSFSArray("items");
        //        if (packItems.Count <= 6)
        //        {
        //            for (int j = 0; j < packItems.Count; j++)
        //            {
        //                ISFSObject item_ = packItems.GetSFSObject(j);

        //                PackItemExp packItem = new PackItemExp(item_.GetUtfString("EquipmentId"),0,
        //                    item_.GetUtfString("EntityName"), item_.GetInt("level"));
        //                pack.Add(packItem);
        //            }
        //        }
                
        //    }
        //    PackExpFighterEntity packExpFighter =  AddEntity(item.GetUtfString("fighterId"),item.GetUtfString("EntityName"), item.GetInt("level"), item.GetInt("exp"),item.GetInt("price"),item.GetInt("evolution"), pack.ToArray());
        //    lstPack.Add(packExpFighter);
        //}
        //ListFighterVar.dic_name_list_fighter.Add(listEntitiesName,lstPack);
        //Observer.Instance.Notify(listEntitiesName,ListFighterVar.dic_name_list_fighter[listEntitiesName]);
        //base.OnResponse(data);
       
    }

    protected override void AddEntity(string entityName, int level)
    {
        
    }

    //private PackExpFighterEntity AddEntity(string id, string entityName, int level, int exp,int price,int evolution, PackItem[] items)
    //{
    //    return new PackExpFighterEntity(id, exp, entityName, level,price, items);
    //}
}

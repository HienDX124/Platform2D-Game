using LTA.SFS.Base;
using Sfs2X.Entities.Data;
using System.Collections;
using System.Collections.Generic;
using LTA.DesignPattern;
using UnityEngine;

namespace  lta.stamina
{
    public class SmartFoxStamina : IOnResponse
    {
        public string keyCode;
        public SmartFoxStamina(string keyCode)
        {
            this.keyCode = keyCode;
        }
        
        public void OnResponse(ISFSObject data)
        {
            if (ListUtils<PackItems>.dic_Name_ListObj.ContainsKey(keyCode))
            {
                ListUtils<PackItems>.dic_Name_ListObj[keyCode].Clear();
                ListUtils<PackItems>.dic_Name_ListObj.Remove(keyCode);
            }
            
            ListUtils<PackItems>.dic_Name_ListObj.Clear();
            ISFSArray sfsArr = data.GetSFSArray("Entities");
            for (int i = 0; i < sfsArr.Count; i++)
            {

                ISFSObject stamina = sfsArr.GetSFSObject(i);

                AddRank(stamina.GetInt("stamina"),stamina.GetInt("price"), stamina.GetInt("maxStamina"), stamina.GetLong("endTime"));
            }
            Observer.Instance.Notify(keyCode);

        
        }

        void AddRank(int stamina,int price, int maxStamina, long endTime)
        {
            ListUtils<PackItems>.AddObjRespond(keyCode, new PackItems(){stamina = stamina, price = price, 
                maxStamina = maxStamina,endTime = endTime});
        }
    }    
}



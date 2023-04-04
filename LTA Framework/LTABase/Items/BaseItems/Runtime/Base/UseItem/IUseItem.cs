using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace LTA.Base.Item
{
    public interface IUseItem
    {
        void UseItem(Transform[] targets);
        //void UseItem(Transform target);
        
        UseItemController OwnUseItem { set; }
    }
}

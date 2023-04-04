using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace LTA.Base.Item
{
    public interface IBeUseItem
    {
        void OnBeUseItem(PackItem packItem);
    }
}

using System.Collections;
using System.Collections.Generic;
using LTA.Base.Item;
using UnityEngine;

public class FighterController : MonoBehaviour, IEndAddItemsInfo
{
    private PackItem[] itemsFighter;
    public void SetPackItem(PackItem[] itemsFighter)=>  this.itemsFighter = itemsFighter;
    public void OnEndAddItems()
    {
        if(itemsFighter == null) return;
        UseItemsController useItemsController = GetComponent<UseItemsController>();
        for(int i = 0; i < itemsFighter.Length; i++)
        {
            useItemsController.AddItem(itemsFighter[i]);    
        }
        
    }
}

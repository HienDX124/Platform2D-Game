using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LTA.Base.Item;
using LTA.AutoTarget;
public class NPCCharacterUseItem : NPCUseItem
{

    CharacterItemController characterItem;

    CharacterItemController CharacterItem
    {
        get
        {
            if (characterItem == null)
            {
                characterItem = GetComponentInChildren<CharacterItemController>();
            }
            return characterItem;
        }
    }

    public override void GetTarget(List<Transform> targets)
    {
        oldRargets = targets;
        OnGetTargets(targets);
        CharacterItem.UseItem(targets.ToArray(), OwnUseItem.packItem);
    }

}

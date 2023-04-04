using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LTA.Base.Character;
using LTA.BasicCharacter;
using System;
using LTA.Base.Item;

[System.Serializable]
public class CharacterItemInfo
{
    public string Idle;
    public string Move;
    public string UseItem;
    public string eventUseItem;
    public string sound;
}

public abstract class CharacterItemController : BaseCharaterController
{
    PackItem packItem;

    CharacterItemInfo charaterItemInfo;

    CharacterMoveController characterMoveController;

    CharacterMoveController CharacterMoveController
    {
        get
        {
            if (characterMoveController == null)
            {
                characterMoveController = GetComponent<CharacterMoveController>();
            }
            return characterMoveController;
        }
    }
    CharacterIdleController characterIdleController;

    CharacterIdleController CharacterIdleController
    {
        get
        {
            if (characterIdleController == null)
            {
                characterIdleController = GetComponent<CharacterIdleController>();
            }
            return characterIdleController;
        }
    }
    IOnCharacterUserItem[] onCharacterUseItems;

    UseItemsController useItemsController;

    UseItemsController UseItemsController
    {
        get
        {
            if (useItemsController == null)
                useItemsController = transform.parent.GetComponent<UseItemsController>();
            return useItemsController;
        }
        
    }

    Transform[] targets;
    Transform mainTarget;
    private void Awake()
    {
        AddCharaterState(ItemState.UseItem);
        onCharacterUseItems = GetComponentsInParent<IOnCharacterUserItem>();
    }

    protected abstract Vector3 Direction { set; }

    private void Update()
    {
        if (Main.CurrentState == ItemState.UseItem && onCharacterUseItems != null)
        {
            foreach (IOnCharacterUserItem onCharacterUserItem in onCharacterUseItems)
                onCharacterUserItem.OnCharacterUserItem(charaterItemInfo);
        }
    }
    
    public virtual void UseItem(Transform[] targets,PackItem packItem)
    {
        if (!isEndUseItem) return;
        isEndUseItem = false;
        if (packItem == null|| targets == null || targets.Length == 0)
        {
            isEndUseItem = true;
            return;
        }
        this.targets = targets;
        this.packItem = packItem;
        OnAddItemsInfo();
        mainTarget = targets[targets.Length / 2];
        if (mainTarget == null)
        {
            isEndUseItem = true;
            return;
        }
        Direction = mainTarget.position - transform.position;

        if(!Main.SetState(ItemState.UseItem))
        {
            isEndUseItem = true;
            return;
        }
        if (!String.IsNullOrEmpty(charaterItemInfo.sound) && Main.CurrentState == ItemState.UseItem)
        {
            if(isUseSound) return;
            isUseSound = true;
            MySound.Instance.PlaySound(charaterItemInfo.sound);
        }
    }

    private bool isUseSound = false;

    private bool isEndUseItem = true;
    public override bool CheckCanChangeState(string state)
    {
        return isEndUseItem;
    }

    public override void SetState(string state)
    {
        if (charaterItemInfo == null || !UseItemsController.IsAllowUseItem(packItem.itemName))
        {
            EndUseItem();
            return;
        }
        Animator.SetEndEvent(()=>
        {
            EndUseItem();
        });
        if (charaterItemInfo.eventUseItem != null)
        {
            Animator.SetEvent(charaterItemInfo.eventUseItem, () =>
            {
                if (targets == null || targets.Length == 0)
                {
                    EndUseItem();
                    return;
                }
                UseItemsController.UseItem(packItem.itemName, targets);
            });
        }
        Animator.Play(anim,false);
    }

    void EndUseItem()
    {
        isEndUseItem = true;
        isUseSound = false;
        Main.SetState(BasicState.Idle);
        IOnEndUseItem[] onEndUseItems = GetComponentsInParent<IOnEndUseItem>();
        foreach (IOnEndUseItem onEndUseItem in onEndUseItems)
        {
            onEndUseItem.OnEndUseItem(targets, packItem);
        }
        targets = null;
    }

    public void OnAddItemsInfo()
    {
        PackItem item = UseItemsController.GetItem(packItem);
        if (item == null) return;
        if (!ItemCharacterDataController.Instance.itemOfCharacterVO.CheckKey(item.itemName)) return;
        charaterItemInfo = ItemCharacterDataController.Instance.itemOfCharacterVO.GetData<CharacterItemInfo>(item.itemName,item.level);
        if (charaterItemInfo == null) return;
        CharacterIdleController.ChangeAnim(charaterItemInfo.Idle);
        if (CharacterMoveController != null) CharacterMoveController.ChangeAnim(charaterItemInfo.Move);
        anim = charaterItemInfo.UseItem;
    }
}

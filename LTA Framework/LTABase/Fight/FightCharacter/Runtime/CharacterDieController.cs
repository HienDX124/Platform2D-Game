using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LTA.Base.Character;
public class CharacterDieController : BaseCharaterController,IOnDie,IOnUpLevel
{
    IOnCharacterDie[] onCharacterDies;
    IOnEndAnimDie[] onEndAnimDies;
    [SerializeField] private bool isDestroy = true;
    private void Awake()
    {
        Main.AddCharaterState(FightState.Die, this);
        onCharacterDies = transform.parent.GetComponents<IOnCharacterDie>();
        onEndAnimDies = transform.parent.GetComponentsInChildren<IOnEndAnimDie>();
    }
    public override bool CheckCanChangeState(string state)
    {
        return false;
    }

    protected virtual void Update()
    {
        if (Main.CurrentState == FightState.Die && onCharacterDies != null)
        {
            foreach (IOnCharacterDie onCharacterDie in onCharacterDies)
                onCharacterDie.OnDie();
        }

    }

    public override void SetState(string state)
    {
        Animator.SetEndEvent(EndAnimDie);
        Animator.Play(anim, false);
    }

    public void EndAnimDie()
    {
        Destroy(transform.parent.gameObject);
        if(onEndAnimDies == null) return;
        foreach (IOnEndAnimDie action in onEndAnimDies)
        {
            action.EndAnimDie();
        }
    }

    public void OnDie()
    {
        Main.SetState(FightState.Die);
    }

    public void OnUpLevel(int level)
    {
        originanim = CharacterDataController.Instance.charactersVO.GetAnimName(OwnName, level, FightState.Die);
        anim = originanim;
    }
}

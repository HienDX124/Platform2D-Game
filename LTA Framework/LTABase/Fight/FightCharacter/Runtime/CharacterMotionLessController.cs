
using LTA.Base.Character;
using UnityEngine;
using System.Collections.Generic;
//[DisallowMultipleComponent]
public class CharacterMotionLessController : BaseCharaterController
{
    bool isEnd = false;

    static int count = 0;

    string motionLessName = "";

    //string m_AnimationName;
    private void Awake()
    {
        motionLessName = FightState.MotionLess + count.ToString();
        count++;
        Main.AddCharaterState(motionLessName, this);
    }

    public void SetCharacterMotionLess(string animationName)
    {
        anim = animationName;
        if (transform.parent.name == "Rob")
        {
            Debug.Log("MotionLess 0");
        }
        Main.SetState(motionLessName);
    }

    public override bool CheckCanChangeState(string state)
    {
        if (transform.parent.name == "Rob")
        {
            Debug.Log("MotionLess 0.5 " + state + " " + state.Contains(FightState.MotionLess));
        }
        return state.Contains(FightState.MotionLess) || state == FightState.Die || isEnd;
    }

    public override void SetState(string state)
    {
        if (transform.parent.name == "Rob")
        {
            Debug.Log("MotionLess 1 " + anim);
        }
        Animator.Play(anim);
    }
    
    private void OnDestroy()
    {
        isEnd = true;
        Main.SetState(BasicState.Idle);
        Debug.Log("Parent MotionLess: " + transform.parent.name);
        IEndAnimation[] endAnimations = transform.parent.GetComponents<IEndAnimation>();
        
        foreach (IEndAnimation endAnim in endAnimations)
        {
            endAnim.EndAnimation(anim);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//[DisallowMultipleComponent]
public class CharateterStateController : MonoBehaviour
{

    string currentState = "";
    public string CurrentState
    {
        get
        {
            return currentState;
        }
    }

    Dictionary<string, ICharacterState> dic_CharaterState = new Dictionary<string, ICharacterState>();

    ICharacterState currentCharacter;

    public bool SetState(string state)
    {
        if (transform.parent.name == "Rob")
        {
            Debug.Log("MotionLess 0.51 " + state);
        }
        if (!dic_CharaterState.ContainsKey(state))
        {
            return false;
        }
        if (transform.parent.name == "Rob")
        {
            Debug.Log("MotionLess 0.52 " + state);
        }
        //if (currentState == state) return false;

        if (IsCanChangeState(state))
        {
            currentState = state;
            currentCharacter = dic_CharaterState[state];
            currentCharacter.SetState(state);
            return true;
        }
        if (transform.parent.name == "Rob")
        {
            Debug.Log("MotionLess 0.53 " + state);
        }
        return false;
    }

    protected virtual bool IsCanChangeState(string state)
    {
        return currentCharacter == null || currentCharacter.CheckCanChangeState(state);
    }

    public void AddCharaterState(string state, ICharacterState character)
    {
        if (dic_CharaterState.ContainsKey(state))
        {
            dic_CharaterState[state] = character;
        }
        else
        {
            dic_CharaterState.Add(state, character);
        }
    }
}

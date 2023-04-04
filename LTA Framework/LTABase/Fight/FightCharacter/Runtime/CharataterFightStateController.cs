using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LTA.BasicCharacter;
public class CharataterFightStateController : CharateterStateController
{
    protected override bool IsCanChangeState(string state)
    {
        return base.IsCanChangeState(state) || state == FightState.Die || state.Contains(FightState.MotionLess);
    }
}

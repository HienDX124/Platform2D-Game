using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICharacterState
{
    void SetState(string state);
    bool CheckCanChangeState(string state);
}

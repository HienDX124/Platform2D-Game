using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace LTA.BasicCharacter
{
    public interface IOnCharacterMove
    {
        void OnMove(Vector3 direction);
    }
}

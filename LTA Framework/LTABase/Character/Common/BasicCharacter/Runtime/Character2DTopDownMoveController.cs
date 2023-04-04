using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace LTA.BasicCharacter.Character2D.TopDown
{
    public class Character2DTopDownMoveController : CharacterMoveController
    {

        protected override void UpdateState(Vector3 direction)
        {
            transform.up = direction;
            base.UpdateState(direction);
        }
    }
}

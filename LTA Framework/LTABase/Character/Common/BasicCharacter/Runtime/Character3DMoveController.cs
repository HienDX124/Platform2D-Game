using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace LTA.BasicCharacter.Character3D
{
    public class Character3DMoveController : CharacterMoveController
    {
        protected override void UpdateState(Vector3 direction)
        {
            transform.forward = direction;
            base.UpdateState(direction);
        }
    }
}

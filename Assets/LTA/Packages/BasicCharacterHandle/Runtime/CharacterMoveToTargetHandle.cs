
using UnityEngine;
using LTA.Base.Item;
using LTA.BasicCharacter;
public class CharacterMoveToTargetHandle : MonoBehaviour
{
    public UseItemController OwnUseItem
    {
        get
        {
            return ownUseItem;
        }
        set
        {
            ownUseItem = value;
        }
    }

    private UseItemController ownUseItem;

    CharacterMoveController characterMove;

    CharacterMoveController CharacterMove
    {
        get
        {
            if (characterMove == null) characterMove = GetComponentInChildren<CharacterMoveController>();
            return characterMove;
        }
    }

    public void UseItem(Transform[] targets)
    {
        if (targets.Length == 0)
        {
            return;
        }
        Vector3 direction = targets[0].position - transform.position;
        characterMove.Direction = direction;
    }
}

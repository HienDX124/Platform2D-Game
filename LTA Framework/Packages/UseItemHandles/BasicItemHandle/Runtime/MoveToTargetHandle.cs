using UnityEngine;
using LTA.Base.Item;
public class MoveToTargetHandle : MonoBehaviour,IUseItem
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

    MoveController move;

    MoveController Move
    {
        get
        {
            if (move == null) move = GetComponent<MoveController>();
            return move;
        }
    }

    public void UseItem(Transform[] targets)
    {
        if (targets.Length == 0) return;
        Vector3 direction = targets[0].position - transform.position;
        Move.Move(direction);
    }


}

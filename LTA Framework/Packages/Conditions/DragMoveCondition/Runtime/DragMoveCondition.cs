using System.Collections;
using System.Collections.Generic;
using LTA.Condition;
using UnityEngine;
public class DragMoveInfo
{
    public bool isDrag = false;
}

public class DragMoveCondition : BaseConditionEffect<DragMoveInfo>, IOnDragDown, IOnDragUp
{

    private bool isDrag;
    public override object Info
    {
        set
        {
            isDrag = ((DragMoveInfo)value).isDrag;
            OnSuitableCondition(true);
        }
    }

    public void OnDragDown()
    {
        if(isDrag)
            OnSuitableCondition(true);
        else
        {
            OnSuitableCondition(false);
        }
    }

    public void OnDragUp()
    {
        if(isDrag)
            OnSuitableCondition(false);
        else
        {
            OnSuitableCondition(true);
        }
    }
    
    
}

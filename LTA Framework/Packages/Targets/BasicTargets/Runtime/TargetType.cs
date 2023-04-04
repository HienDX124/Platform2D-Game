using UnityEngine;
using LTA.Base;
[System.Serializable]
public class TargetTypeInfo
{
    public string[] types;
}

public class TargetType : MonoBehaviour,ISetInfo,ICheckTarget
{
    [SerializeField]
    TargetTypeInfo info;

    public object Info { set
        {
            info = (TargetTypeInfo)value;
        }
    }

    public bool IsHasType(string checkType)
    {
        foreach(string type in info.types)
        {
            if (type == checkType) return true;
        }
        return false;
    }

    public bool CheckTarget(Transform target)
    {
        LTAType targetType = target.GetComponent<LTAType>();
       
        foreach(string type in info.types)
        {
            if (type == targetType.type) return true;
        }

        return false;
    }
}

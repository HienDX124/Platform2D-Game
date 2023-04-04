using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LTA.Base.Item;
using LTA.VO;
using System.Reflection;

public class TypeAddObjectPos
{
    public const string LOCAL_POS = "LocalPos";
    public const string WORLD_POS = "WorldPos";
    public const string LINKED_POS = "LinkedPos";
    public const string FOLLOW_OWN_POS = "FollowOwnPos";
    public const string FOLLOW_TARGET_POS = "FollowTargetPos";
}

[System.Serializable]
public class AddObjectInfo : AddComponentInfo
{
    public string path = "";
    public string Name;
    public int level;
    public string typePos = TypeAddObjectPos.LOCAL_POS;
    public Vector3 pos =  Vector3.zero;
    public Vector3 scale = Vector3.one;
}

public interface IOnAddObjectToTarget
{
    void OnAddObject(GameObject gameObject);
}

public class AddObjectHandle : BaseUseItemEffect<AddObjectInfo>
{
    public override void UseItem(Transform target)
    {
        //Debug.Log("type effect "+ target.gameObject.GetComponent<LTAType>().type);
        if (target == null && (info.typePos == TypeAddObjectPos.LINKED_POS || info.typePos == TypeAddObjectPos.FOLLOW_TARGET_POS || info.typePos == TypeAddObjectPos.LOCAL_POS))
        {
            return;
        }
        GameObject newObject;
        if (info.path == "")
            newObject = new GameObject();
        else
        {
            GameObject prefab = GlobalVO.GetAsset.GetAsset<GameObject>(info.path);
            newObject = Instantiate(prefab);
        }
        switch (info.typePos)
        {
            case TypeAddObjectPos.LOCAL_POS:
                newObject.transform.SetParent(target);
                //newObject.transform.localPosition = info.pos;
                newObject.transform.localPosition = Vector3.zero;
                break;
            case TypeAddObjectPos.WORLD_POS:
                newObject.transform.position = info.pos;
                break;
            case TypeAddObjectPos.LINKED_POS:
                newObject.transform.position = (transform.position + target.position) / 2;
                float distance = Vector3.Distance(transform.position, target.position);
                newObject.transform.right = transform.position - newObject.transform.position;
                Debug.Log("LinkedPos " + distance);
                newObject.transform.localScale = new Vector3(distance * 0.55f, 1, 1);
                break;
            case TypeAddObjectPos.FOLLOW_OWN_POS:
                newObject.transform.position = transform.position + info.pos;
                break;
            case TypeAddObjectPos.FOLLOW_TARGET_POS:
                newObject.transform.position = target.position + info.pos;
                break;
        }
        if (info.typePos != TypeAddObjectPos.LINKED_POS)
            newObject.transform.localScale = info.scale;
        ComponentInfo[] components = info.components;
        if (components != null)
        {
            foreach (ComponentInfo component in components)
            {
                Assembly assembly = Assembly.Load(component.assemblyName);
                newObject.AddComponent(assembly.GetType(component.type));
            }
        }
        newObject.name = info.Name;
        NonEntityController nonEntityController = newObject.AddComponent<NonEntityController>();
        nonEntityController.SetLevel(info.level);
        IOnAddObjectToTarget[] onAddObjectToTargets = GetComponentsInChildren<IOnAddObjectToTarget>();
        foreach (IOnAddObjectToTarget onAddObjectToTarget in onAddObjectToTargets)
        {
            onAddObjectToTarget.OnAddObject(newObject);
        }
    }
}

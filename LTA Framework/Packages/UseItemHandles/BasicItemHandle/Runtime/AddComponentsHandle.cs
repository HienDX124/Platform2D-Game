using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LTA.Base.Item;
using System.Reflection;

[System.Serializable]
public class ComponentInfo
{
    public string assemblyName;
    public string type;
}

[System.Serializable]
public class AddComponentInfo
{
    public ComponentInfo[] components;
}

public class AddComponentsHandle : BaseUseItemEffect<AddComponentInfo>
{
    List<Component> own_Components = new List<Component>();

    public override void UseItem(Transform target)
    {
        //base.UseItem(target);
        ComponentInfo[] components = info.components;

        foreach (ComponentInfo component in components)
        {
            Assembly assembly = Assembly.Load(component.assemblyName);
            Component current_Component = target.gameObject.AddComponent(assembly.GetType(component.type));
            if (current_Component == null) continue;
            own_Components.Add(current_Component);
        }
    }


}

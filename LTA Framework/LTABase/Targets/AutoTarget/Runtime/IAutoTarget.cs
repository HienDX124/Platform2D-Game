using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace LTA.AutoTarget
{
    public interface IAutoTarget
    {
        void AddAutoTarget(IGetTargetsAuto getTargetsAuto);
        void RemoveAutoTarget(IGetTargetsAuto targetsAuto);
    }
}

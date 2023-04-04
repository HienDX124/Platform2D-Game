using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace LTA.AutoTarget
{
    public interface IGetTargetsAuto : IHunter
    {
        int numTarget
        {
            get;
        }
        bool IsReturnNoTarget {
            get;
        }

        bool IsChangeTarget
        {
            get;
        }

        List<Transform> OldTargets
        {
            get;
        }

        void GetTarget(List<Transform> targets);
    }
}

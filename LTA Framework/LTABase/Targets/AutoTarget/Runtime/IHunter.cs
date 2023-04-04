
using UnityEngine;
namespace LTA.AutoTarget
{
    public interface IHunter
    {
        bool IsAllowAutoTarget { get; }

        FilterTargetController Filter
        {
            get;
        }
    }
}

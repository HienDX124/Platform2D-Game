
using System.Collections.Generic;
using UnityEngine;

namespace LTA.AutoTarget
{
    public class Target
    {
        public static List<Transform> GetTatgets(List<Target> targets)
        {
            List<Transform> results = new List<Transform>();
            foreach (Target target in targets)
            {
                results.Add(target.target.transform);
            }
            return results;
        }
        public TargetController target;
        public Target(TargetController target)
        {
            this.target = target;
        }
    }
    public class TargetController : MonoBehaviour /*,ICameraMove*/
    {
        static List<TargetController> targets = new List<TargetController>();
        
        public static Transform GetTarget(IHunter hunter)
        {
            if (!hunter.IsAllowAutoTarget) return null;
            TargetController bestTarget = null;
            FilterTargetController filter = hunter.Filter;
            foreach (TargetController target in targets)
            {

                if (filter == null || !filter.CheckTarget(target.transform)) continue;
                if (bestTarget == null || filter.CheckBestTarget(bestTarget.transform,target.transform))
                {
                    bestTarget = target;
                }
            }
            if (bestTarget != null)
                return bestTarget.transform;
            return null;
        }

        public static List<Transform> GetTargets(IGetTargetsAuto getTargetsAuto)
        {
            if (!getTargetsAuto.IsAllowAutoTarget) return null;
            if (getTargetsAuto.numTarget == 0) return new List<Transform>();
            List<Target> bestTargets = new List<Target>();
            if (getTargetsAuto.numTarget == 1)
            {
                List<Transform> results = new List<Transform>();
                Transform target = GetTarget(getTargetsAuto);
                if (target != null)
                    results.Add(target);
                return results;
            }
            FilterTargetController filter = getTargetsAuto.Filter;
            foreach (TargetController target in targets)
            {
                if (filter == null || !filter.CheckTarget(target.transform)) continue;
                if (bestTargets.Count == getTargetsAuto.numTarget)
                {
                    Target removeTarget = null;
                    foreach (Target bestTarget in bestTargets)
                    {
                        if (!filter.CheckBestTarget(target.transform,bestTarget.target.transform))
                        {
                            removeTarget = bestTarget;
                        }
                    }
                    if (removeTarget == null)
                    {
                        continue;
                    }
                    bestTargets.Remove(removeTarget);
                }
                bestTargets.Add(new Target(target));

            }
            return Target.GetTatgets(bestTargets);
        }

        private void Awake()
        {
            targets.Add(this);
        }

        private void OnDestroy()
        {
            if (targets.Contains(this))
                targets.Remove(this);
        }
    }
}

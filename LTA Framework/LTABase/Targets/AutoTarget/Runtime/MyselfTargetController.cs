using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace LTA.AutoTarget
{
    public class MyselfTargetController : MonoBehaviour,IAutoTarget
    {
        List<IGetTargetsAuto> getTargetsAutos = new List<IGetTargetsAuto>();

        List<Transform> targets = new List<Transform>();

        private void Awake()
        {
            targets.Add(transform);
        }

        public void AddAutoTarget(IGetTargetsAuto getTargetsAuto)
        {
            getTargetsAutos.Add(getTargetsAuto);
        }

        public void RemoveAutoTarget(IGetTargetsAuto targetsAuto)
        {
            getTargetsAutos.Remove(targetsAuto);
        }

        bool isProcessing = false;

        void Update()
        {

            if (getTargetsAutos == null || getTargetsAutos.Count == 0) return;
            if (isProcessing) return;
            isProcessing = true;
            foreach (IGetTargetsAuto getTargetsAuto in getTargetsAutos)
            {
                if (!getTargetsAuto.IsAllowAutoTarget) continue;
                getTargetsAuto.GetTarget(targets);
            }
            isProcessing = false;
        }
    }
}

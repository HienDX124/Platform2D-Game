using System;
using System.Collections.Generic;
using UnityEngine;
namespace LTA.AutoTarget
{
    [DisallowMultipleComponent]
    public class AutoTargetsController : MonoBehaviour,IAutoTarget
    {
        List<IGetTargetsAuto> getTargetsAutos = new List<IGetTargetsAuto>();

        Dictionary<IGetTargetsAuto, List<Transform>> dic_autoTargets_targets = new Dictionary<IGetTargetsAuto, List<Transform>>();

        public List<IGetTargetsAuto> GetTargetsAutos
        {
            get
            {
                return getTargetsAutos;
            }
        }

        public Dictionary<IGetTargetsAuto, List<Transform>> Dic_autoTargets_targets
        {
            get
            {
                return dic_autoTargets_targets;
            }
        }

        public void AddAutoTarget(IGetTargetsAuto getTargetsAuto)
        {
            getTargetsAutos.Add(getTargetsAuto);
        }

        public void RemoveAutoTarget(IGetTargetsAuto targetsAuto)
        {
            if (getTargetsAutos.Contains(targetsAuto))
                getTargetsAutos.Remove(targetsAuto);
            if (dic_autoTargets_targets.ContainsKey(targetsAuto))
                dic_autoTargets_targets.Remove(targetsAuto);
        }
        [SerializeField]
        bool isProcessing = false;
        // Update is called once per frame
        
        void Update()
        {
            if (getTargetsAutos == null || getTargetsAutos.Count == 0) return;
            if (dic_autoTargets_targets.Count == 0) return;
            if (isProcessing) return;
            isProcessing = true;
            try
            {
                foreach (IGetTargetsAuto getTargetsAuto in getTargetsAutos)
                {
                    if (!getTargetsAuto.IsAllowAutoTarget) continue;
                    if (!dic_autoTargets_targets.ContainsKey(getTargetsAuto)) continue;
                    List<Transform> targets = dic_autoTargets_targets[getTargetsAuto];
                    if (targets == null) continue;
                    if (targets.Count == 0 && !getTargetsAuto.IsReturnNoTarget) continue;
                    getTargetsAuto.GetTarget(targets);
                }
            }
            catch (Exception ex)
            {
                Debug.LogError(ex.Message);
            }
            isProcessing = false;
        }
        private void LateUpdate()
        {
            if (isProcessing) return;
            isProcessing = true;
            try
            {
                foreach (IGetTargetsAuto getTargetsAuto in getTargetsAutos)
                {
                    if (!getTargetsAuto.IsAllowAutoTarget)
                    {
                        if (!dic_autoTargets_targets.ContainsKey(getTargetsAuto))
                        {
                            dic_autoTargets_targets.Add(getTargetsAuto, null);
                        }
                        else
                        {
                            dic_autoTargets_targets[getTargetsAuto] = null;
                        }
                        continue;
                    }
                    if (!getTargetsAuto.IsChangeTarget && getTargetsAuto.OldTargets != null && getTargetsAuto.OldTargets.Count > 0)
                    {
                        bool isContinue = true;
                        foreach (Transform target in getTargetsAuto.OldTargets)
                        {
                            if (target == null || !getTargetsAuto.Filter.CheckTarget(target))
                            {
                                isContinue = false;
                                break;
                            }
                        }
                        if (isContinue)
                        {
                            
                            continue;
                        }
                    }
                    List<Transform> targets = TargetController.GetTargets(getTargetsAuto);

                    if (!dic_autoTargets_targets.ContainsKey(getTargetsAuto))
                    {
                        dic_autoTargets_targets.Add(getTargetsAuto, targets);
                    }
                    else
                    {
                        dic_autoTargets_targets[getTargetsAuto] = targets;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.LogError(ex.Message);
            }
            isProcessing = false;
        }
    }
}

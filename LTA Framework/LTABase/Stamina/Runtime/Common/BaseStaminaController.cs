using System;
using System.Collections;
using System.Collections.Generic;
using LTA.DesignPattern;
using TMPro;
using UnityEngine;
using UnityEngine.Diagnostics;
using UnityEngine.UI;

namespace lta.stamina
{
    [RequireComponent(typeof(TimeDown))]
    public abstract class BaseStaminaController : MonoBehaviour
    {

        [SerializeField] private TMP_Text txtStamina;
        [SerializeField] private TMP_Text txtMaxStamina;
        [SerializeField] private Image processBarImage;

        private TimeDown timeDown;
        protected virtual void Awake()
        {
            timeDown = GetComponent<TimeDown>();
        }

        public virtual void OnUpdateData(object sender)
        {
            PackItems staminaRemoteLoad = (PackItems) sender;
            if(staminaRemoteLoad == null) return;
            txtStamina.text = staminaRemoteLoad.stamina.ToString();
            txtMaxStamina.text = staminaRemoteLoad.maxStamina.ToString();
            processBarImage.fillAmount = (float)staminaRemoteLoad.stamina / (float)staminaRemoteLoad.maxStamina;
            Debug.LogError("time   "+ (LTA.Base.Utils.UnixTimeToDateTime(staminaRemoteLoad.endTime)- DateTime.Now).Hours);
            int hours = (LTA.Base.Utils.UnixTimeToDateTime(staminaRemoteLoad.endTime) - DateTime.Now).Hours;
            int minutes = (LTA.Base.Utils.UnixTimeToDateTime(staminaRemoteLoad.endTime) - DateTime.Now).Minutes;
            timeDown.StartTimeDown((LTA.Base.Utils.UnixTimeToDateTime(staminaRemoteLoad.endTime)- DateTime.Now).Seconds + (hours * 3600) + (minutes * 60) );
        }

       
        protected virtual void OnClickBuy(PackItems itemBuy)
        {
            // send request buy item
        }
        
    }

}
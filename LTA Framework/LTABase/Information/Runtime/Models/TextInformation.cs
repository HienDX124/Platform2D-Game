using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System;

[Serializable]
public class TextInfor
{
    public string type;
    public string value;
}
public abstract class TextInformation : MonoBehaviour, IInformation
{
    [SerializeField] private TextInfoType textInfoType;
    [SerializeField] private TMP_Text txtInformation;
    public virtual void OnSetInformation(string value)
    {
        txtInformation.text = value;
    }

    public TextInfoType GetType() => this.textInfoType;
}

public enum TextInfoType
{
    Title = 0 ,
    Price ,
    Tiers
}
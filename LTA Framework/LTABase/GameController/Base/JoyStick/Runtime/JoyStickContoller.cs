
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using LTA.Effect;
using System;
using LTA.Base;
public class  JoyStickContoller : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    protected Vector3 direction;

    protected Vector3 posJoyStick;

    [SerializeField]
    protected Transform joyStick;

    [SerializeField]
    protected Transform BgJoyStick;

    Vector3 OriginalPos;

    EffectController effectJoyStick;

    EffectController effectBgJoyStick;

    Action<Vector3> endDrag;

    public Action<Vector3> EndDrag
    {
        set
        {
            endDrag = value;
        }
    }
    [SerializeField]
    protected float maxLength = 70f;

    public Vector3 Direction
    {
        get
        {
            return direction;
        }
    }

    public Vector3 PosJoyStick
    {
        get
        {
            return posJoyStick;
        }
    }

    public float MaxLegnth {
        get
        {
            return maxLength;
        }
    }

    protected virtual void Start()
    {
        OriginalPos = BgJoyStick.transform.position;
        maxLength = BgJoyStick.GetComponent<RectTransform>().sizeDelta.x <= 0 ? 70 : (BgJoyStick.GetComponent<RectTransform>().sizeDelta.x / 2);
        effectBgJoyStick = BgJoyStick.GetComponent<EffectController>();
        effectJoyStick = joyStick.GetComponent<EffectController>();
    }

    public virtual void OnBeginDrag(PointerEventData eventData)
    {
        BgJoyStick.position = eventData.position;
        direction = Vector3.zero;
        if (effectBgJoyStick != null)
            effectBgJoyStick.ShowEffect(TypeEffect.Drag);
        if (effectJoyStick != null)
            effectJoyStick.ShowEffect(TypeEffect.Drag);
    }

    public void OnDrag(PointerEventData eventData)
    {
        MoveJoyStick(eventData.position);
    }

    public virtual void OnEndDrag(PointerEventData eventData)
    {
        if (endDrag != null)
            endDrag(direction);
        direction = Vector3.zero;
        joyStick.transform.localPosition = Vector3.zero;
        BgJoyStick.position = OriginalPos;
        posJoyStick = joyStick.localPosition;
        if (effectBgJoyStick != null)
            effectBgJoyStick.HideEffect(TypeEffect.Drag);
        if (effectJoyStick != null)
            effectJoyStick.HideEffect(TypeEffect.Drag);
        
    }

    protected virtual void MoveJoyStick(Vector3 touchPos)
    {
        Vector2 offset = touchPos - BgJoyStick.position;
        Vector3 realdirection = Vector2.ClampMagnitude(offset, maxLength);
        direction = realdirection.normalized;
        joyStick.position = new Vector3(BgJoyStick.position.x + realdirection.x, BgJoyStick.position.y + realdirection.y, joyStick.position.z);
        posJoyStick = joyStick.localPosition;
    }

}

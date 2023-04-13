using System.Collections;
using System.Collections.Generic;
using Mono.CompilerServices.SymbolWriter;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler
{
    private Image bgBtn;
    private Vector3 startPosition;

    public delegate void Do();
    public Do doSomething;
    void Start()
    {
        bgBtn = GetComponent<Image>();
        startPosition = transform.position;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        transform.localScale = transform.localScale * 2;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        transform.position = startPosition;
        transform.localScale = transform.localScale / 2;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (doSomething != null)
        {
            doSomething();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchInputHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public delegate void OnStickValueUpdated(bool isGettingTouchInputValue);
    public static event OnStickValueUpdated onStickValueUpdated;
    
    public void OnPointerDown(PointerEventData eventData)
    {
        onStickValueUpdated?.Invoke(true);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        onStickValueUpdated?.Invoke(false);
    }
}

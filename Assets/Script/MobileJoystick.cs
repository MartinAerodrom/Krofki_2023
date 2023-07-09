using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class MobileJoystick : MonoBehaviour, IPointerUpHandler, IDragHandler, IPointerDownHandler
{
    private RectTransform joystickTransform;

    [SerializeField]
    private float dragTreshold = 0.6f;
    [SerializeField]
    private int dragMovementDistance = 30;
    [SerializeField]
    private int dragOffsetDistance = 100;

    public event Action<Vector2> OnMove;

public void OnDrag(PointerEventData eventData)
{
    Vector2 offset;
    RectTransformUtility.ScreenPointToLocalPointInRectangle(
        joystickTransform,
        eventData.position,
        null,
        out offset);
        offset = Vector2.ClampMagnitude(offset, dragOffsetDistance) / dragOffsetDistance;
        joystickTransform.anchoredPosition = offset * dragMovementDistance;

        Vector2 inputVector = CalculateMovementInput(offset);
        OnMove?.Invoke(inputVector);
        Debug.Log(offset);

}

private Vector2 CalculateMovementInput(Vector2 offset)
{
    float x = MathF.Abs(offset.x) > dragTreshold ? offset.x : 0;
    float y = MathF.Abs(offset.y) > dragTreshold ? offset.y : 0;
    return new Vector2(x,y);
}

public void OnPointerDown(PointerEventData eventData)
{

}

public void OnPointerUp(PointerEventData eventData)
{
    joystickTransform.anchoredPosition = Vector2.zero;
    OnMove?.Invoke(Vector2.zero);
}
private void Awake()
{
    joystickTransform = (RectTransform)transform;
}

}

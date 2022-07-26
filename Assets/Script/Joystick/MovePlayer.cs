using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MovePlayer : MonoBehaviour
{
    public GameObject joystick;
    public GameObject joystickBG;
    
    public Vector2 joystickVec;
    private Vector2 joystickTouchPos;
    private Vector2 joystickOriginalPos;
    private float joystickRadius;

    public void Start()
    {
        joystickOriginalPos = joystickBG.transform.position;
        joystickRadius = joystickBG.GetComponent<RectTransform>().sizeDelta.y /72 -3;
        Debug.Log(joystickRadius);
    }
    public void PointerDown()
    {
        Vector2 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        joystick.transform.position = new Vector3(mousepos.x, mousepos.y, 0);
        joystickBG.transform.position = new Vector3(mousepos.x, mousepos.y, 0);
        joystickTouchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
    public void Drag(BaseEventData BaseEventData)
    {
        PointerEventData pointerEventData = BaseEventData as PointerEventData;
        Vector2 dragPos = Camera.main.ScreenToWorldPoint(pointerEventData.position);
        joystickVec = (dragPos - joystickTouchPos).normalized;

        float joystickDist = Vector2.Distance(dragPos, joystickTouchPos);
        Vector2 ChangePos;
        if (joystickDist < joystickRadius)
            ChangePos = joystickTouchPos + joystickVec * joystickDist;
        else
            ChangePos = joystickTouchPos + joystickVec * joystickRadius;
        joystick.transform.position = new Vector3(ChangePos.x, ChangePos.y, 0);
    }
    public void PointerUp()
    {
        joystickVec = Vector2.zero;
        joystick.transform.position = joystickOriginalPos;
        joystickBG.transform.position = joystickOriginalPos;
    }
}

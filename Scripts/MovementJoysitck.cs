using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class MovementJoysitck : MonoBehaviour
{
    public GameObject joystick;
    public GameObject joysitckBG;

    public Vector2 joysiickVec; //vector chinh de dieu khien joysick va player

    private Vector2 joystickTouchPos;
    private Vector2 joysickOriginalPos;

    private float joysitckRadius;

    // Start is called before the first frame update
    void Start()
    {
        joysickOriginalPos = joysitckBG.transform.position;
        joysitckRadius = joysitckBG.GetComponent<RectTransform>().sizeDelta.y / 3;
    }

    public void PointerDown()
    {
        joystick.transform.position = Input.mousePosition;
        joysitckBG.transform.position = Input.mousePosition;
        joystickTouchPos = Input.mousePosition;
    }

    public void Drag(BaseEventData baseEventData)
    {
        PointerEventData pointerEventData = baseEventData as PointerEventData;
        Vector2 dragPos = pointerEventData.position;
        joysiickVec = (dragPos - joystickTouchPos).normalized;

        float joysickDist = Vector2.Distance(dragPos, joystickTouchPos);

        if (joysickDist < joysitckRadius)
        {
            joystick.transform.position = joystickTouchPos + joysiickVec * joysickDist;
        }
        else
        {
            joystick.transform.position = joystickTouchPos + joysiickVec * joysitckRadius;
        }

    }

    public void PointerUp()
    {
        joysiickVec = Vector2.zero;
        joystick.transform.position = joysickOriginalPos;
        joysitckBG.transform.position = joysickOriginalPos;
    }

    //private void Update()
    //{
    //    joystick.transform.position += new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0) * 2;
    //}
   
}

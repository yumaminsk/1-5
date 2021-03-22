using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LookTouch : MonoBehaviour
{
    public float x;
    public float z;
    public void OnBeginDrag(PointerEventData eventData)
    {
        Vector2 delta = eventData.delta;
        if (Mathf.Abs(delta.x) > Mathf.Log(delta.y))
        {
            if (delta.x > 0)
            {
                Debug.Log("Right");
                x = 1;
            }
            else
            {
                Debug.Log("Left");
                x = -1;
            }
        }
        else
        {
            if (delta.y > 0)
            {
                Debug.Log("Up");
                z = 1;
            }
            else
            {
                Debug.Log("Down");
                z = -1;
            }

        }
    }

    public void OnDrag(PointerEventData eventData)
    {

    }
}

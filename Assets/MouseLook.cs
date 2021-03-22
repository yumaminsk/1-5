using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensivity = 100f;
    public Transform playerBody;
    float xRotation = 0f;
    public Joystick joystick;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float MouseX = joystick.Horizontal * mouseSensivity * Time.deltaTime;
        float MouseY = -joystick.Vertical * mouseSensivity * Time.deltaTime;

        xRotation -= MouseY;
        xRotation = Mathf.Clamp(xRotation, -20f, 20f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        playerBody.Rotate(Vector3.up * MouseX);
    }
}



using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ControlTouch : MonoBehaviour
{
    public float Gravity = -9.81f;
    public float Speed = 10.0f;
    public CharacterController controller;
    public float jumpHeight = 2.0f;
    Vector3 velocity;
    public Vector3 movement;
    bool isGrounded;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public Joystick joystik;
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        float x = joystik.Horizontal;
        float z = joystik.Vertical;

        movement = transform.right * x + transform.forward * -z;
        controller.Move(movement * Speed * Time.deltaTime);

       

        velocity.y += Gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
    public void jump()
    {
        Debug.Log(isGrounded);
        if (isGrounded) 
        {
            velocity.y += Mathf.Sqrt(jumpHeight * -2f * Gravity);
        }
    }
   
}
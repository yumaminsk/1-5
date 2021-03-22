using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
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


    // Update is called once per frame
    void Update()
    {
        Move();

    }
    public void Move()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        float x = Input.GetAxis("Vertical");
        float z = Input.GetAxis("Horizontal");

        movement = transform.right * -z + transform.forward * -x;
        controller.Move(movement * Speed * Time.deltaTime);

       
        velocity.y += Gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

    }
    void Jump()
    {
        velocity.y += Mathf.Sqrt(jumpHeight * -2f * Gravity);
    }

}

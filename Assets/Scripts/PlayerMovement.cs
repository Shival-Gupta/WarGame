using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController characterController;
    
    [SerializeField] public float walkSpeed = 8f, sprintSpeed = 12f, jumpHeight = 3f, gravity = -9.81f, groundDistance = 0.4f;
    public Transform groundCheck;
    public LayerMask groundMask;
    [SerializeField] bool isGrounded;
    Vector3 velocity;

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
            velocity.y = -2f; // constant downforce : gravity

        // Move - WASD
        float x = Input.GetAxis("Horizontal"); // A D
        float z = Input.GetAxis("Vertical"); // W S

        Vector3 move = (transform.right * x + transform.forward * z).normalized; // Local Axis from Player
        characterController.Move(move * (Input.GetKey(KeyCode.LeftShift) ? walkSpeed : sprintSpeed) * Time.deltaTime); // Moves Player WASD

        // Jump
        if(Input.GetButtonDown("Jump") && isGrounded)
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity); // Jump

        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime); // Vertical Movement : Jump & Gravity
    }
}

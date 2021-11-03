using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] CharacterController controller;

    [Header("Movement")]
    [SerializeField] float movementSpeed = 8f;
    [SerializeField] GameObject playerCamera;
    float TurnSmoothTime = 0.1f;
    float TurnSmoothVelocity;


    [Header("Jumping")]
    float yVelocity;
    float gravity = -9.81f;
    float JumpForce = 27f;
    float FallMultiplier = 10f;



    void Start()
    {

    }

    void Update()
    {

        CheckJump();

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 moveDir = new Vector3(h, 0, v).normalized;

        if (moveDir.magnitude > 0f)
        {
            float angle = Mathf.Atan2(moveDir.x, moveDir.z) * Mathf.Rad2Deg + playerCamera.transform.eulerAngles.y;
            float smoothAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, angle, ref TurnSmoothVelocity, TurnSmoothTime);
            transform.rotation = Quaternion.Euler(0, smoothAngle, 0);

            moveDir = Quaternion.Euler(0, angle, 0).normalized * Vector3.forward;

        }

        controller.Move((moveDir * movementSpeed + CheckJump()) * Time.deltaTime);

    }

    private Vector3 CheckJump()
    {

        if (Input.GetButtonDown("Jump") && controller.isGrounded)
        {
            yVelocity = JumpForce;
        }
        if (!controller.isGrounded)
        {
            yVelocity += gravity * (FallMultiplier-2) * Time.deltaTime;
        }
        else if (!controller.isGrounded && !Input.GetButton("Jump"))
        {
            yVelocity += gravity * (FallMultiplier - 1) * Time.deltaTime;
        }

        return new Vector3(0,yVelocity,0);
    }

}

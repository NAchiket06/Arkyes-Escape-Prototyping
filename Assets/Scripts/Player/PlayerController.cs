using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] CharacterController controller;

    [Header("Movement")]
    [SerializeField] float movementSpeed = 2f;
    [SerializeField] GameObject playerCamera;
    float TurnSmoothTime = 0.1f;
    float TurnSmoothVelocity;


    [Header("Jumping")]
    [SerializeField] float JumpForce = 5f;
    [SerializeField] float FallMultiplier = 1.5f;

    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
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

            controller.Move(moveDir * movementSpeed * Time.deltaTime);
        }
    }

    private void CheckJump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = Vector3.up * JumpForce;
        }
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector3.up * Physics.gravity.y * FallMultiplier * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (FallMultiplier - 1) * Time.deltaTime;
        }
    }

}

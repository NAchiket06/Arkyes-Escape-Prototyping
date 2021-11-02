using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [Header("Movement")]
    [SerializeField] float movementSpeed = 2f;

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
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        if(Input.GetButtonDown("Jump"))
        {
            rb.velocity = Vector3.up * JumpForce;
        }
        if(rb.velocity.y<0)
        {
            rb.velocity += Vector3.up * Physics.gravity.y * FallMultiplier * Time.deltaTime;
        }
        else if (rb.velocity.y >0 && !Input.GetButton("Jump"))
        {
            rb.velocity += Vector3.up * Physics.gravity.y * Time.deltaTime;
        }

        Vector3 moveDir = new Vector3(h,0,v).normalized * (FallMultiplier -1)* movementSpeed* Time.deltaTime;
        transform.Translate(moveDir);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;

    private Rigidbody rb3D;
    private Vector3 moveVelocity;
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb3D = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Vector3 moveInput = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        moveVelocity = moveInput.normalized * speed;

        if (moveInput != Vector3.zero)
        {
            anim.SetBool("isRunning", true);
        }
        else {
            anim.SetBool("isRunning", false);
        }
    }

    private void FixedUpdate() => rb3D.MovePosition(rb3D.position + moveVelocity * Time.fixedDeltaTime);
}

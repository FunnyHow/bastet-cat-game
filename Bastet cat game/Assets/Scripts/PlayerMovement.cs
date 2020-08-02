using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController2D))]
public class PlayerMovement : MonoBehaviour
{

    private CharacterController2D controller;
    private bool jump = false;
    private float horizontalMove = 0f;
    public float runSpeed = 40f;
    public bool wasActionDown = false;

    void Start() {
        controller = GetComponent<CharacterController2D>();
    }

    void Update()
    {
        HandleActions();
        HandleMovement();
    }

    private void HandleMovement()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
    }

    private void HandleActions()
    {
        if (!wasActionDown && Input.GetButton("Submit"))
        {
            controller.TryAction();
        }
        wasActionDown = Input.GetButton("Submit");
    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    public float walkSpeed = 5.0f;
    public float sprintSpeed = 10.0f;
    public float turnSpeed = 1.0f;
    public float jumpHeight = 1.0f;
    
    public Camera playerCamera;

    CharacterController characterController;
    Rigidbody rb;
    float yRotation;
    float xRotation;
    bool sprinting = false;
    Vector3 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        CameraRotation();
        Movement();
    }

    void CameraRotation()
    {
        xRotation = Mathf.Clamp(xRotation, -90, 90);

        playerCamera.transform.eulerAngles = new Vector3(-xRotation, transform.eulerAngles.y + yRotation, 0);
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + yRotation, 0);
    }

    void Movement()
    {
        float currentSpeed = walkSpeed;
        if (sprinting) currentSpeed = sprintSpeed;

        Vector3 currentMovement = movement;

        currentMovement.x *= currentSpeed;
        currentMovement.z *= currentSpeed;

        currentMovement = transform.TransformDirection(currentMovement);

        //Gravity
        if (!characterController.isGrounded) movement.y -= 9.85f * Time.deltaTime;
        else movement.y -= 0.05f * Time.deltaTime;

        characterController.Move(currentMovement * Time.deltaTime);
        
    }

    #region Controls

    void OnMove(InputValue value)
    {
        if (MenuManager.inMenu) return;

        movement.x = Mathf.Clamp(value.Get<Vector2>().x, -1.0f, 1.0f);
        movement.z = Mathf.Clamp(value.Get<Vector2>().y, -1.0f, 1.0f);
    }

    void OnSprint()
    {
        if (MenuManager.inMenu) return;

        sprinting = !sprinting;
    }

    void OnJump()
    {
        if (MenuManager.inMenu) return;

        if (characterController.isGrounded)
            movement.y = jumpHeight;
    }

    void OnMouseX(InputValue value)
    {
        if (MenuManager.inMenu) return;

        yRotation = value.Get<float>() * turnSpeed;
    }

    void OnMouseY(InputValue value)
    {
        if (MenuManager.inMenu) return;

        xRotation += value.Get<float>() * turnSpeed;
    }

    #endregion
}

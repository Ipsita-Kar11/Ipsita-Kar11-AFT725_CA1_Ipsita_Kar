using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float gravity = 9.8f;
    public float jumpSpeed = 20f;
    public float verticalSpeed = 0f;

    Vector2 movementInput;
    public float movementSpeed;


    public void IAmovement(InputAction.CallbackContext context)

    {
        movementInput = context.ReadValue<Vector2>();
        Debug.Log("IAmovement is working");
    }
    public bool GroundCheck()
    {
        return Physics.Raycast(transform.position, transform.up * -1, 2f);
    }
    void Start()
    {

    }
    void Update()
    {
        if (GroundCheck() == true && verticalSpeed <= 0)
        {
            verticalSpeed = 0;
            Debug.Log("on Ground");
        }
        else
        {
            verticalSpeed = verticalSpeed - gravity * Time.deltaTime;
            Debug.Log("Not Ground");
        }
        transform.Translate(movementInput.x * movementSpeed * Time.deltaTime, verticalSpeed * Time.deltaTime, movementInput.y * movementSpeed * Time.deltaTime);
    }
    public void IAjump(InputAction.CallbackContext context)
    {
        if (context.started == true && GroundCheck())
        {
            verticalSpeed = jumpSpeed;

            Debug.Log("Started");
        }
    }
}
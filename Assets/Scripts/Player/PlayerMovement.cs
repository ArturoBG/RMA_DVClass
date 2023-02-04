using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 0.1f;
    private CharacterController characterController;
      

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    public void Move(Vector2 input)
    {
        Debug.Log("input x: "+input.x+ " y: " + input.y );
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;

        characterController.Move(this.transform.TransformDirection(moveDirection) * speed * Time.deltaTime);
    }

    public void Fire(InputAction.CallbackContext context)
    {
        Debug.Log("Fire");        
    }

    

}

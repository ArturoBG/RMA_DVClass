using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    public void Move(Vector2 input)
    {
        Debug.Log("Input x: "+input.x+ " y " + input.y );
    }

    public void Fire(InputAction.CallbackContext context)
    {
        Debug.Log("Fire");        
    }

    

}

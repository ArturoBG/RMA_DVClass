using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float gravity = -9.81f;

    [SerializeField]
    private Vector3 playerVelocity;

    [SerializeField]
    private float jumpingHeight = 5f;

    [SerializeField]
    private bool isGrounded = false;

    public float speed = 0.1f;

    [SerializeField]
    private float defaultSpeed = 1f;

    [SerializeField]
    private float sprintSpeed = 2f;

    private CharacterController characterController;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        isGrounded = characterController.isGrounded;
    }

    public void Move(Vector2 input)
    {
        // Debug.Log("input x: " + input.x + " y: " + input.y);
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;

        characterController.Move(this.transform.TransformDirection(moveDirection) * speed * Time.deltaTime);

        //Gravity
        playerVelocity.y += gravity * Time.deltaTime;
        characterController.Move(playerVelocity * Time.deltaTime);

        //check if grounded
        if (isGrounded == true && playerVelocity.y < 0)
        {
            playerVelocity.y = -1f;
        }
    }

    public void Jump()
    {
        //Debug.Log("Jump!");
        //Modify if needed
        float jumpForce = Mathf.Abs(jumpingHeight * gravity);
        // Debug.Log("Force " + jumpForce);

        if (isGrounded == true)
        {
            playerVelocity.y = jumpForce;
        }
    }

    public void Sprint(bool isPressed)
    {
        if (isPressed)
        {
            Debug.Log("Sprint speed");
            speed = sprintSpeed;
        }
        else
        {
            Debug.Log("default speed");
            speed = defaultSpeed;
        }
    }

    public void Fire(InputAction.CallbackContext context)
    {
        Debug.Log("Fire");
    }
}
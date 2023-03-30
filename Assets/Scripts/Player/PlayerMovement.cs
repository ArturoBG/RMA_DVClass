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

    [Header("Animation Settings")]
    private Animator animator;
    int moveXAnimationId;
    int moveZAnimationId;
    [SerializeField]
    private Vector2 animationVelocity;
    [SerializeField]
    private float smoothFactor = 0.1f;

    //smooth damp
    Vector3 currentAnimationBlend;

    private CharacterController characterController;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

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
        //MoveDirection for Animation purposes
        Vector3 moveDirectionAnim = Vector3.zero;
        moveDirectionAnim.x = input.x;
        moveDirectionAnim.y = input.y;
                
        //Smooth animation
        currentAnimationBlend = Vector2.SmoothDamp(currentAnimationBlend, moveDirectionAnim, ref animationVelocity, smoothFactor );
        //Debug.Log("currentanimblendvector " + currentAnimationBlend.x + " " + currentAnimationBlend.y + " " + currentAnimationBlend.z);

        //Animator call and movement
        animator.SetFloat("moveX", currentAnimationBlend.x);
        animator.SetFloat("moveZ", currentAnimationBlend.y);

        //MoveDirection for character controller
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
    
}
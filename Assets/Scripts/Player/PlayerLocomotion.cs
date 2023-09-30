using System.Collections;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class PlayerLocomotion : MonoBehaviour
{
    [SerializeField]
    private Vector3 playerVelocity = new Vector3();

    [SerializeField]
    private float defaultSpeed = 5f;

    [SerializeField]
    private float sprintSpeeed = 10f;

    [SerializeField]
    private float gravity = -9.8f;

    [SerializeField]
    private bool isGrounded = false;

    [SerializeField]
    private float jumpingHeight = 5f;

    private CharacterController characterController;

    private Animator playerAnimator;

    private Vector2 currentAnimationBlend;
    private Vector2 animationVelocity;
    [SerializeField]
    private float animationSmoothFactor = 0.1f;

    [Header("Shield and Sword Constraints")]
    [SerializeField]
    MultiAimConstraint shieldShoulderConstraint; 
    [SerializeField]
    MultiAimConstraint swordhoulderConstraint;
    [SerializeField]
    AnimationClip swordClip;
    [SerializeField]
    RigBuilder rig;
    private void Awake()
    {
        playerAnimator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        isGrounded = characterController.isGrounded;
        if (!isGrounded)
        {
            //is midair
        }
    }

    public void MoveCharacter(Vector2 input)
    {
       // Debug.Log("Input {"+input.x + "}. {"+ input.y+"}");
        Vector3 moveDirectionAnimation = Vector3.zero;
        Vector2 animationBlending = Vector2.zero;
        moveDirectionAnimation.x = input.x;
        animationBlending.x = input.x;
        moveDirectionAnimation.z = input.y;
        animationBlending.y = input.y;
        
        //Movement of character controller
        characterController.Move(transform.TransformDirection(moveDirectionAnimation) * defaultSpeed * Time.deltaTime);

        //animation movement
        
        currentAnimationBlend = Vector2.SmoothDamp(currentAnimationBlend, animationBlending, ref animationVelocity, animationSmoothFactor);
        //Debug.Log("Current animation blend x:"+currentAnimationBlend.x +"  y:" +currentAnimationBlend.y);

        playerAnimator.SetFloat("MoveZ", currentAnimationBlend.y);
        playerAnimator.SetFloat("MoveX", currentAnimationBlend.x);

        playerVelocity.y += gravity * Time.deltaTime;
        characterController.Move(playerVelocity * Time.deltaTime);

        if (isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = -1f;
        }
    }

    public void Jump()
    {      
        if (isGrounded)
        {
            float jumpForce = Mathf.Abs(jumpingHeight * gravity);
            playerVelocity.y = jumpForce;
            //animator=> jump animation
        }
    }

    public void Attack()
    {
        StartCoroutine(swordAttackRoutine());
    }

    /// <summary>
    ///  Shield se levante con bool en true y baje con bool en false
    ///  TODO
    /// </summary>
    public void Shield(bool raise)
    {
        //TODO bug: walk animation se entromete en shield animation, 
        //animation rigging para siempre ver hacia delante
        if (raise)
        {
            playerAnimator.SetBool("shield", true);
            shieldShoulderConstraint.data.offset = new Vector3(30f,57f,6.4f);
        }
        else
        {
            playerAnimator.SetBool("shield", false);
            shieldShoulderConstraint.data.offset = new Vector3(0, 0, 0);
        }
    }

    IEnumerator swordAttackRoutine()
    {
        playerAnimator.SetTrigger("swordAttack");
        yield return new WaitForSeconds(swordClip.length);
    }
}

using UnityEditor.Rendering.LookDev;
using UnityEngine;
using UnityEngine.InputSystem.Interactions;
using UnityEngine.InputSystem;
using UnityEditor;

namespace Scripts.PlayerScripts 
{
    public class PlayerLocomotion : MonoBehaviour
    {
        //first part

        private CharacterController controller;

        [SerializeField]
        private Vector3 playerVelocity;

        [SerializeField]
        private float defaultSpeed = 5f;

        [SerializeField]
        private float sprintSpeed = 15f;

        [SerializeField]
        private float speed = 5f;

        private WeaponScript weaponScript;

        //second part
        public float gravity = -9.8f;

        [SerializeField]
        private bool isGrounded = true;

        public float jumpingHeight = 5f;

        [Header("Animation settings")]
        [SerializeField]
        private float animationSmoothFactor = 0.1f;
        private Animator animator;
        int moveXAnimationId;
        int moveZAnimationId;

        //smooth damp
        Vector3 currentAnimationBlendVector;
        Vector2 animationVelocity;

        private void Awake()
        {
            weaponScript = GetComponent<WeaponScript>();
            animator = GetComponent<Animator>();
        }

        private void Start()
        {
            controller = GetComponent<CharacterController>();

            //animations id
            moveZAnimationId = Animator.StringToHash("vertical");
            moveXAnimationId = Animator.StringToHash("horizontal");
        }

        //part 2
        private void Update()
        {
            isGrounded = controller.isGrounded;
        }

        public void Move(Vector2 input)
        {
            //first part
            Vector3 moveDirectionAnimation = Vector3.zero;
            moveDirectionAnimation.x = input.x;
            moveDirectionAnimation.y = input.y;
            //animator
            currentAnimationBlendVector = Vector2.SmoothDamp(currentAnimationBlendVector, moveDirectionAnimation, ref animationVelocity, animationSmoothFactor);

            //Debug.Log("currentanimblendvector " + currentAnimationBlendVector.x +" " +  currentAnimationBlendVector.y+" " + currentAnimationBlendVector.z);

            animator.SetFloat(moveXAnimationId, currentAnimationBlendVector.x);
            animator.SetFloat(moveZAnimationId, currentAnimationBlendVector.y);

            //move the character controller
            Vector3 moveDirection = Vector3.zero;
            moveDirection.x = input.x;
            moveDirection.z = input.y;
            controller.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);

            ///second part
            playerVelocity.y += gravity * Time.deltaTime;
            controller.Move(playerVelocity * Time.deltaTime);

            if (isGrounded && playerVelocity.y < 0)
            {
                playerVelocity.y = -1f;
            }
        }

        // third part
        public void FireWeapon(InputAction.CallbackContext context)
        {
            switch (context.phase)
            {
                case InputActionPhase.Performed:
                    if (context.interaction is SlowTapInteraction)
                    {
                        //Debug.Log("Charging weapon");
                        weaponScript.ShootBulletWRigidBody(true);
                    }
                    else
                    {
                        weaponScript.ShootBulletWRigidBody(false);
                    }
                   
                    break;

                case InputActionPhase.Started:
                    if (context.interaction is SlowTapInteraction)
                    {
                        Debug.Log("started slow tap");
                    }
                       
                    break;

                case InputActionPhase.Canceled:
                    //Debug.Log("canceled slow tap");
                    break;
            }

            //  first part
           /// weaponScript.ShootBulletWRigidBody();
        }

        public void Jump()
        {
            float jumpForce = Mathf.Abs(jumpingHeight * gravity);
            if (isGrounded)
            {
                // Debug.Log("Jumping " + jumpForce);

                playerVelocity.y = jumpForce;
            }
        }

        public void Sprint(bool sprint)
        {
            if(sprint)
                speed = sprintSpeed;
            else
                speed = defaultSpeed;
        }

    }
}
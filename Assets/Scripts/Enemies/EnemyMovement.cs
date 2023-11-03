using Cinemachine.Utility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{

    private bool IsWalking = false;
    private Vector2 currentAnimationBlend;
    private Vector2 animationVelocity;
    public Animator animator;
    public NavMeshAgent agent;
    [SerializeField]
    private float animationSmoothFactor = 0.1f;

    [SerializeField]
    private Transform playerTransform;
    [SerializeField]
    private Vector3 offset;
    [SerializeField]
    private Transform ballEffectorTarget;
    [SerializeField] private Vector3 ballEffectorOriginalPosition;
    [SerializeField]
    private EnemyAttackDistance enemyAttackDistance;

    Vector3 localDirection;
    private void Start()
    {
        ballEffectorOriginalPosition = ballEffectorTarget.localPosition;
    }

    private void Update()
    {
        if (IsWalking && playerTransform != null)
        {
           
            MoveToPosition(playerTransform);
            if (enemyAttackDistance.IsAtDistance)
            {
                ballEffectorTarget.position = new Vector3(playerTransform.position.x, playerTransform.position.y + 1.5f, playerTransform.position.z);
                //animate the attack movement
                animator.SetTrigger("attack");
            }
            else
            {
                ballEffectorTarget.localPosition = ballEffectorOriginalPosition;
            }
            //MoveCharacter(new Vector2(this.transform.position.x, this.transform.position.z));
        }
        else
        {
            localDirection = Vector3.zero;
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.tag.Equals("Player"))
        {
            Debug.Log("Player found!");
            //get player reference
            playerTransform = other.transform;
            //go to player and attack
            IsWalking = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            Debug.Log("Player lost!");
            IsWalking = false;
            //resume patrol\
            playerTransform = null;
            
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

        //animation movement
        currentAnimationBlend = Vector2.SmoothDamp(currentAnimationBlend, animationBlending, ref animationVelocity, animationSmoothFactor);
        //Debug.Log("Current animation blend x:"+currentAnimationBlend.x +"  y:" +currentAnimationBlend.y);

        animator.SetFloat("MoveZ", currentAnimationBlend.y);
        animator.SetFloat("MoveX", currentAnimationBlend.x);
    }

    public void MoveToPosition(Transform newPos)
    {
        Vector3 position = new Vector3( newPos.position.x + offset.x , newPos.position.y + offset.y, newPos.position.z + offset.z );
        agent.SetDestination( position );

        localDirection = transform.InverseTransformDirection(agent.velocity);
        //Debug.Log("NPC localdirection x"+localDirection.x +" y"+ localDirection.y+" z"+ localDirection.z);
        animator.SetFloat("MoveX", localDirection.x);
        animator.SetFloat("MoveZ", localDirection.z);

    }
}

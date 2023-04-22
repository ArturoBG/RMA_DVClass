using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyController : MonoBehaviour
{


    [Header("Enemy Settings")]
    NavMeshAgent agent;
    WeaponScript weapon;
    Animator animator;
    [SerializeField]
    private Transform playerPosition;
    public LayerMask groundLayer;
    public LayerMask playerLayer;
    //STATES
    //walking
    public Vector3 navPoint;
    [SerializeField]
    bool navPointSet;
    [SerializeField]
    private float sightRange;
    [SerializeField]
    private Vector3 distanceToPlayer;
    //chasing
    [SerializeField]
    private bool playerInSightRange;
    //attacking
    public bool playerInAttackRange;
    public float offsetToPlayer;
    public float timerToAttack = 5f;
    public bool timeToShoot;
    public float attackRange;
    bool alreadyAttacking;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        weapon = GetComponent<WeaponScript>();
        playerPosition = FindObjectOfType<PlayerController>().GetComponent<Transform>();
        agent = GetComponent<NavMeshAgent>();
    }

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        //StartCoroutine(AttackCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, playerLayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, playerLayer);

        if (!playerInSightRange && !playerInAttackRange)
        {
            Walk(); // Patrol
        }
        if (playerInSightRange && !playerInAttackRange)
        {
            Chase();
        }
        if (playerInSightRange && playerInAttackRange)
        {
            Attack();
        }
    }

    private void Walk()
    {
        Debug.Log("idle/patrol/walking");
    }

    private void Chase()
    {
        Debug.Log("Chasing!");

        if (playerPosition != null)
        {
            distanceToPlayer = new Vector3(playerPosition.position.x + offsetToPlayer, playerPosition.position.y, playerPosition.position.z + offsetToPlayer);
            // TODO
            // send x and z to enemy movement
            // call animator for movement
            agent.SetDestination(distanceToPlayer);
        }
        else
        {
            return;
        }
    }

    private void Attack()
    {
        Debug.Log("Attack!");
        if (playerPosition != null)
        {
            //shoot the player
            if (!alreadyAttacking)
            {
                weapon.Shoot();
                alreadyAttacking = true;
                Invoke(nameof(ResetAttack), timerToAttack);
            }
            //turn to player
            transform.LookAt(playerPosition);
        }
    }

    private void ResetAttack()
    {
        alreadyAttacking = false;
    }

    /// <summary>
    /// Callback to draw gizmos that are pickable and always drawn.
    /// </summary>
    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

}

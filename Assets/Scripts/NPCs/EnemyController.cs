using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Scripts.PlayerScripts
{   
    [RequireComponent(typeof(NavMeshAgent), typeof(WeaponScript))]
    public class EnemyController : MonoBehaviour
    {
        private WeaponScript weapon;

        public NavMeshAgent agent;
        public Transform Player;
        public LayerMask groundLayer;
        public LayerMask playerLayer;

        //patrol
        public Vector3 navPoint;
        bool navPointSet;
        public float patrolRange;
        Vector3 distanceToPlayer;
        //Attack
        public float timeBetweenAttacks;
        public float offsetToPlayer;
        public float attackRange;
        bool alreadyAttacking;

        //States
        public bool playerInSightRange;
        public bool playerInAttackRange;

        /// <summary>
        /// Awake is called when the script instance is being loaded.
        /// </summary>
        void Awake()
        {   
            weapon = GetComponent<WeaponScript>();
            //look for player on scene
            Player = FindObjectOfType<PlayerController>().GetComponent<Transform>();
            agent = GetComponent<NavMeshAgent>();
        }

        /// <summary>
        /// Update is called every frame, if the MonoBehaviour is enabled.
        /// </summary>
        void Update()
        {
            playerInSightRange = Physics.CheckSphere(transform.position, patrolRange, playerLayer);
            playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, playerLayer);

            //states 

            if (!playerInSightRange && !playerInAttackRange)
            {
                //Patrol();
            }
            if (playerInSightRange && !playerInAttackRange)
            {
                ChasePlayer();
            }
            if (playerInAttackRange && playerInSightRange)
            {
                AttackPlayer();
            }

        }

        private void Patrol()
        {
            Debug.Log("walking");
            
        }

        private void ChasePlayer()
        {
            Debug.Log("Chasing after player!");

            distanceToPlayer = new Vector3(Player.transform.position.x + offsetToPlayer, Player.transform.position.x,
                Player.transform.position.z);

            if (Player != null)
            {
                agent.SetDestination(distanceToPlayer);
            }
            else
            {
                return;
            }

        }

        private void AttackPlayer()
        {
            Debug.Log("Attack");
            if (Player != null)
            {
                //shoot at player
                weapon.ShootBulletWRigidBody(false);
                transform.LookAt(Player);
            }

        }

        /// <summary>
        /// Callback to draw gizmos that are pickable and always drawn.
        /// </summary>
        void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, patrolRange);

            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, attackRange);
        }



    }

}


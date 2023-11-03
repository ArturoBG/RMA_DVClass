using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{
    [SerializeField]
    private HealthScript healthScript;


    [Header("Enemy Settings")]
    public EnemyType enemyTypeSO;
    public bool damageTaken = false;

    [SerializeField]
    private float damage;

    [SerializeField]
    private float health;

    public EnemyMovement enemyMovement;


    [SerializeField]
    private float timer = 5f;

    private void Start()
    {
        enemyMovement.agent.speed = enemyTypeSO.Speed;
        timer = enemyTypeSO.timerToDamage;
    }

  
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("PlayerWeapon") && !damageTaken)
        {
            StartCoroutine(damageReceived(other));
        }
    }

    private IEnumerator damageReceived(Collider other)
    {
        damageTaken = true;
        Debug.Log("Damage taken");
        enemyMovement.animator.SetTrigger("damage");
        healthScript.TakeDamage(other.GetComponent<WeaponScript>().weaponDamage);
        yield return new WaitForSeconds(timer);
        damageTaken = false;
    }

 
}
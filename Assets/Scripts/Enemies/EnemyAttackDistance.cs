using UnityEngine;

public class EnemyAttackDistance : MonoBehaviour
{
    public bool IsAtDistance = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            IsAtDistance = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            IsAtDistance = false;
        }
    }
}
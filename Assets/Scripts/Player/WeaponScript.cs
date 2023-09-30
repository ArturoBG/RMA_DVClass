using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    public int weaponDamage;

    [SerializeField]
    private BoxCollider collider;

    private void Start()
    {
        collider.GetComponent<Collider>();
        collider.enabled = false;
    }

    public void turnOnCollider()
    {
        collider.enabled = true;
    }

    public void turnOffCollider()
    {
        collider.enabled = false;
    }
}

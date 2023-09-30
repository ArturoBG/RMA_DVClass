using UnityEngine;

public class PlayerWeapons : MonoBehaviour
{
    [SerializeField]
    WeaponScript sword;

    public void TurnOnSwordCollider()
    {
        sword.turnOnCollider();
    }
    public void TurnOffSwordCollider()
    {
        sword.turnOffCollider();
    }
}

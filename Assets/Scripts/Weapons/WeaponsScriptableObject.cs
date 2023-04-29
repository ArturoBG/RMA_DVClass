using UnityEngine;

[CreateAssetMenu(fileName = "TiposDeArmas", menuName = "Inventario/armas", order =1)]
public class WeaponsScriptableObject : ScriptableObject
{
    //prefab bullet
    public GameObject bulletSystem;
    //prefab flash o explosion of weapon
    public GameObject bulletMuzzlePrefab;
    //prefab explosion on collsion
    public GameObject bulletExplosion;
    public float speedToShoot;
    public float bulletSpeed;
    public float damage;
}

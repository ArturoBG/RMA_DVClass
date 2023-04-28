using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponType", menuName = "Arsenal/WeaponType", order = 1)]
public class WeaponTypes : ScriptableObject
{
    public GameObject bulletMuzzlePrefab;
    public GameObject weaponParticleSystem;
    public GameObject bulletExplosion;
    
    public float speedToShoot;
    public float bulletSpeed;
    public float damage;
}

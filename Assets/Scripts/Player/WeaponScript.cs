using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform muzzleTransform;
    public float bulletSpeed;

    public void Shoot()
    {
        GameObject bulletGO = Instantiate(bulletPrefab, muzzleTransform.position, Quaternion.identity);
        
        //BUG 
        //bulletGO.GetComponent<Rigidbody>().AddForce(muzzleTransform.forward * bulletSpeed, ForceMode.Impulse);
    
        
        Rigidbody rb = bulletGO.GetComponent<Rigidbody>();

        rb.AddForce( muzzleTransform.forward * bulletSpeed, ForceMode.Impulse);
        
    }

    
}

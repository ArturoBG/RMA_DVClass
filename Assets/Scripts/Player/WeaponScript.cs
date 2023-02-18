using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform muzzleTransform;
    public float projectileSpeed;
    public ParticleSystem weaponFlash;

    public void Shoot()
    {        
        GameObject bulletGO = Instantiate(projectilePrefab, muzzleTransform.position, Quaternion.identity);
        //BUG
        //bulletGO.GetComponent<Rigidbody>().AddForce(muzzleTransform.forward * bulletSpeed, ForceMode.Impulse);
        Rigidbody rb = bulletGO.GetComponent<Rigidbody>();
        rb.AddForce(muzzleTransform.forward * projectileSpeed, ForceMode.Impulse);
        //muzzle flash particle system
        weaponFlash.Play();
    }
}
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    [Header("Player Arsenal")]
    public WeaponsScriptableObject[] weapon;
    public Transform muzzleTransform;

    private GameObject projectilePrefab;    
    private float projectileSpeed;
    private GameObject weaponFlash;

    private void Start()
    {
        //Always 0 at start
        InitWeapon();
    }

    public void Shoot()
    {        
        GameObject bulletGO = Instantiate(projectilePrefab, muzzleTransform.position, Quaternion.identity);
        GameObject flashGO = Instantiate(weaponFlash, muzzleTransform.position, Quaternion.identity);

        ParticleSystem flash = flashGO.GetComponent<ParticleSystem>();
        flash.Play();

        //Change projectile properties with SO
        ProjectileScript ps = bulletGO.GetComponent<ProjectileScript>();
        
        //TODO change weapon number
        ps.projectileExplosionPrefab = weapon[0].bulletExplosion;
        //
        
        
        Rigidbody rb = bulletGO.GetComponent<Rigidbody>();
        rb.AddForce(muzzleTransform.forward * projectileSpeed, ForceMode.Impulse);
        //muzzle flash particle system
        
    }

    private void InitWeapon(int number = 0)
    {
        projectilePrefab = weapon[number].bulletSystem;
        projectileSpeed = weapon[number].bulletSpeed;
        weaponFlash = weapon[number].bulletMuzzlePrefab;
    }

    public void SelectWeapon(int option)
    { 
        ///
        switch (option)
        {
            case 0:
                //change to pistol
                InitWeapon(0);
                break;
            case 1:
                //change to rifle
                InitWeapon(1);
                break;
            case 2:
                //change to rocket launcher
                InitWeapon(2);
                break;
            

        }

    }
     


}
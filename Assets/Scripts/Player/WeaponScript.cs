using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    [Header("Player Arsenal")]
    public WeaponsScriptableObject[] weapon;
    public Transform muzzleTransform;

    private GameObject projectilePrefab;    
    private float projectileSpeed;
    private GameObject weaponFlash;

    [SerializeField]
    private int weaponSelected = 0;

    private void Start()
    {
        //Always 0 at start
        ChangeWeapon();
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
        ps.projectileExplosionPrefab = weapon[weaponSelected].bulletExplosion;
        //
        
        
        Rigidbody rb = bulletGO.GetComponent<Rigidbody>();
        rb.AddForce(muzzleTransform.forward * projectileSpeed, ForceMode.Impulse);
        //muzzle flash particle system
        
    }

    private void ChangeWeapon(int number = 0)
    {
        Debug.Log("weapon selected "+number);
       
        weaponSelected = number;
        projectilePrefab = weapon[number].bulletSystem;
        projectileSpeed = weapon[number].bulletSpeed;
        weaponFlash = weapon[number].bulletMuzzlePrefab;
    }

    public void SelectWeapon(int option)
    {
        Debug.Log("Option "+option);
        ///
        switch (option)
        {
            case 0:
                //change slot 1
                ChangeWeapon(0);
                break;
            case 1:
                //change slot 2 
                ChangeWeapon(1);
                break;
            case 2:
                //change slot 3
                ChangeWeapon(2);
                break;
            

        }

    }
     


}
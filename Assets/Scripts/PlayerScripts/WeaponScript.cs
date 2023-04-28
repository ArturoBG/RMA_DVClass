using System.Collections;
using UnityEngine;

namespace Scripts.PlayerScripts
{
    public class WeaponScript : MonoBehaviour
    {
        //these can be removed after

        private GameObject bulletPrefab;

        private GameObject bulletMuzzlePrefab;

        private GameObject bulletExplosion;

        private float bulletSpeed;

        private float weaponShootSpeed;

        private Transform muzzle;

        private float massFactor = 2;

        [SerializeField]
        private bool timeToShoot = true;

        [Header("Player arsenal")]
        public WeaponTypes[] weapons;

        public GameObject[] weaponGOList;
        public int weaponSelected;

        //first part, shooting bullets
        public void ShootBulletWRigidBody(bool chargedUp)
        {
            StartCoroutine(SpawnBullet(chargedUp));
        }

        private IEnumerator SpawnBullet(bool chargedUp)
        {
            yield return new WaitForEndOfFrame();

            if (timeToShoot)
            {
                timeToShoot = false;

                GameObject bulletMuzzle = Instantiate(bulletMuzzlePrefab, muzzle.position, Quaternion.identity);
                ParticleSystem ps = bulletMuzzle.GetComponent<ParticleSystem>();
                ps.Play();

                GameObject bulletGO = Instantiate(bulletPrefab, muzzle.position, Quaternion.identity);
                //Vector3 bulletforce = new Vector3(0, 0, this.transform.localPosition.z) * bulletSpeed;

                Vector3 bulletforce = muzzle.transform.forward * bulletSpeed;

                // Debug.Log(bulletforce);
                Rigidbody rb = bulletGO.GetComponent<Rigidbody>();

                if (chargedUp)
                {
                    BulletScript bullet = bulletGO.GetComponent<BulletScript>();
                    bullet.colliderRadius = 1;
                    bulletGO.transform.localScale = new Vector3(5, 5, 5);
                    rb.mass = rb.mass * massFactor;
                }

                rb.AddForce(bulletforce, ForceMode.Impulse);
                yield return new WaitForEndOfFrame();
                yield return StartCoroutine(countToShoot());
            }
        }

        //fourth part initialize the weapon values
        private void Start()
        {
            AssignWeaponValues(0);
        }

        public void SelectWeapon(int weapon)
        {
            switch (weapon)
            {
                case 0:
                    AssignWeaponValues(0); //pistol
                    break;

                case 1:
                    AssignWeaponValues(1); //rifle
                    break;

                case 2:
                    AssignWeaponValues(2); //something else
                    break;
            }
        }

        private void AssignWeaponValues(int num)
        {
            foreach (GameObject gun in weaponGOList)
            {
                gun.GetComponent<GunScript>().gunReference.SetActive(false);
            }
            GunScript gs = weaponGOList[num].GetComponent<GunScript>();

            bulletPrefab = weapons[num].weaponParticleSystem;

            bulletMuzzlePrefab = weapons[num].bulletMuzzlePrefab;

            bulletExplosion = weapons[num].bulletExplosion;

            bulletSpeed = weapons[num].bulletSpeed;

            weaponShootSpeed = weapons[num].speedToShoot;

            muzzle = gs.muzzleReference;

            gs.SetNewReferencesInGun();
        }

        private IEnumerator countToShoot()
        {
            yield return new WaitForSeconds(weaponShootSpeed);
            timeToShoot = true;
        }
    }
}
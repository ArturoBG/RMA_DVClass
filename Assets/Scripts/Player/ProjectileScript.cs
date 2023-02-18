using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    [SerializeField]
    private GameObject projectileExplosionPrefab;

    [SerializeField]
    private SphereCollider sphereCollider;

    private void FixedUpdate()
    {
        if (GetComponent<Rigidbody>().velocity.magnitude != 0)
        {
            transform.rotation = Quaternion.LookRotation(GetComponent<Rigidbody>().velocity);
        }

        //raycast laser colision algun objeto, regresar info de ese objeto
        RaycastHit hit;
        //conseguir la direccion del proyectil, usar para deteccion de la colision
        Vector3 direction = transform.GetComponent<Rigidbody>().velocity;
        direction = direction.normalized;


    }

}

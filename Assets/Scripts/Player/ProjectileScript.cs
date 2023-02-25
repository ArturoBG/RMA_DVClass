using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(SphereCollider))]
public class ProjectileScript : MonoBehaviour
{    
    public GameObject projectileExplosionPrefab;

    [SerializeField]
    private SphereCollider sphereCollider;

    public float offset = 1.5f;
    private float colliderRadius = 1f;

    private void FixedUpdate()
    {
        //Detection distance
        float detectionDistance = transform.GetComponent<Rigidbody>().velocity.magnitude * Time.deltaTime;

        if (GetComponent<Rigidbody>().velocity.magnitude != 0)
        {
            transform.rotation = Quaternion.LookRotation(GetComponent<Rigidbody>().velocity);
        }

        //Radio
        float radius;

        if (transform.GetComponent<SphereCollider>())
        {
            radius = transform.GetComponent<SphereCollider>().radius;
        }
        else
        {
            radius = colliderRadius;
        }

        //raycast laser colision algun objeto, regresar info de ese objeto
        RaycastHit hit;

        //conseguir la direccion del proyectil, usar para deteccion de la colision
        Vector3 direction = transform.GetComponent<Rigidbody>().velocity;
        direction = direction.normalized;


        if (Physics.SphereCast(transform.position, radius, direction, out hit, detectionDistance))
        {
            transform.position = hit.point + (hit.normal*offset);
            GameObject impactParticle = Instantiate(projectileExplosionPrefab, transform.position, Quaternion.FromToRotation(Vector3.up, hit.normal)) as GameObject;

            Destroy(impactParticle, 3f);
            Destroy(gameObject);

        }

    }
}
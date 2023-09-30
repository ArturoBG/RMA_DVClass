using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeComponent : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Yo;
    public Transform miTransform;
    public float speed;
    public float jump;
    public bool canJump = false;
    void Start()
    {
        miTransform = Yo.GetComponent<Transform>();     
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            Debug.Log("Press W");
            miTransform.position = new Vector3(miTransform.position.x , miTransform.position.y, miTransform.position.z + speed );
        }
        if (Input.GetKey(KeyCode.S))
        {
             Debug.Log("Press S");
            miTransform.position = new Vector3(miTransform.position.x , miTransform.position.y, miTransform.position.z - speed );
        }
        if (Input.GetKey(KeyCode.A))
        {
             Debug.Log("Press A");
            miTransform.position = new Vector3(miTransform.position.x - speed , miTransform.position.y, miTransform.position.z );
        } 
        if (Input.GetKey(KeyCode.D))
        {
             Debug.Log("Press D");
            miTransform.position = new Vector3(miTransform.position.x + speed , miTransform.position.y, miTransform.position.z );
        }

        if (canJump)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                miTransform.position = new Vector3(miTransform.position.x, miTransform.position.y + jump, miTransform.position.z);
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("enter "+collision.gameObject.name);
        if (collision.gameObject.name == "Ground")
        {
            canJump = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("exit "+collision.gameObject.name);
        if (collision.gameObject.name == "Ground")
        {
            canJump = false;
        }
    }

}

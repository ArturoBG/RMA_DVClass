using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyComponente : MonoBehaviour
{
    public GameObject miGameobject;
    [SerializeField]
    private Transform GOTransform;
    public GameObject escenario;
    [SerializeField]
    private int entero = 10;
    public float flotante = 10f;
    public Vector3 vectorOnDisable;

    public Vector3 vectorMovement;
    public Vector3 vectorScala;
    public Vector3 vectorRotation;

    public float speed = 0.1f;

    public float scale = 0.001f;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        Debug.Log("Este es AWAKE");        
        GOTransform = miGameobject.GetComponent<Transform>();
        Debug.Log("Transform = "+GOTransform.position);
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Este es Start");
        Debug.Log("Mi nombre es " + miGameobject.name);
        
    }
    
    /// <summary>
    /// This function is called when the object becomes enabled and active.
    /// </summary>
    void OnEnable()
    {
        Debug.Log("Este es OnEnable");
        Debug.Log("Transform OnEnable= "+GOTransform.position);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Este es el Update");
        Debug.Log("mi escenario es " + escenario.name);
        entero += 1;

        if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("presione A");
            vectorMovement = new Vector3(GOTransform.position.x,GOTransform.position.y,GOTransform.position.z + speed);
            GOTransform.position = vectorMovement;
        }



        ///
        // nuevo vector 3 publico
        //update le sumen +0.1f  a eje Z 



    }
    /// <summary>
    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    /// </summary>
    void FixedUpdate()
    {
        Debug.Log("Este es Fixed Update");
    }

    
    /// <summary>
    /// This function is called when the behaviour becomes disabled or inactive.
    /// </summary>
    void OnDisable()
    {
        Debug.Log("Transform OnDisable ");
        
        GOTransform.transform.position = vectorOnDisable;
    }
    /// <summary>
    /// LateUpdate is called every frame, if the Behaviour is enabled.
    /// It is called after all Update functions have been called.
    /// </summary>
    void LateUpdate()
    {
        Debug.Log("Este es LATE UPDATE");
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Scripting.APIUpdating;

public class PlayerController : MonoBehaviour
{
    //
    //Propertie/parameters
    //
    [SerializeField]
    private PlayerMovement playerMovement;
    public SimpleControls playerInput;
    public SimpleControls.GameplayActions gameplayActions;

    public float speed = 5f;

    //functions
    // Start is called before the first frame update
    void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();





        playerInput = new SimpleControls();
        gameplayActions = playerInput.gameplay;
        //gameplayActions.move.performed += ctx => playerMovement. ();
         
    }

    private void OnEnable()
    {
        Debug.Log("OnEnable");
    }

    private void OnDisable()
    {
        Debug.Log("OnDisable");
    }

    public void Start()
    {
        Debug.Log("this is an Start");

    }


    // Update is called once per frame
    void Update()
    {
        Debug.Log("this is an Update");
    }


}

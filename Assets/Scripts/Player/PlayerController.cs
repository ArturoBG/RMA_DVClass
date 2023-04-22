using UnityEngine;


[RequireComponent(typeof(PlayerCameraController), typeof(PlayerMovement), typeof(CharacterController) )]
[RequireComponent(typeof(WeaponScript))]

public class PlayerController : MonoBehaviour
{
    
    //
    //Propertie/parameters
    //
    [SerializeField]
    private PlayerMovement playerMovement;

    [SerializeField]
    private PlayerCameraController cameraController;

    private WeaponScript weaponScript;

    public SimpleControls playerInput;
    public SimpleControls.GameplayActions gameplayActions;

    public float speed = 5f;

    //functions
    // Start is called before the first frame update
    private void Awake()
    {
        //get components from Player
        playerMovement = GetComponent<PlayerMovement>();
        cameraController = GetComponent<PlayerCameraController>();
        weaponScript = GetComponent<WeaponScript>();

        playerInput = new SimpleControls();
        gameplayActions = playerInput.gameplay;
    }

    private void OnEnable()
    {
        //   Debug.Log("OnEnable");
        gameplayActions.Enable();
    }

    private void OnDisable()
    {
        //   Debug.Log("OnDisable");
        gameplayActions.Disable();
    }

    public void Start()
    {
        //Fire
        gameplayActions.fire.performed += ctx => weaponScript.Shoot();

        gameplayActions.jump.performed += ctx => playerMovement.Jump();

        //Sprint action
        gameplayActions.sprint.canceled += ctx => playerMovement.Sprint(false);
        gameplayActions.sprint.performed += ctx => playerMovement.Sprint(true);

        gameplayActions.weapon1.performed += ctx => weaponScript.SelectWeapon(0); //slot 1
        gameplayActions.weapon2.performed += ctx => weaponScript.SelectWeapon(1); //slot 2

        //camera switch
        gameplayActions.switchCamera.performed += ctx => cameraController.SwitchCamera();
    }

    // Update is called once per frame
    private void Update()
    {
        playerMovement.Move(gameplayActions.move.ReadValue<Vector2>());
    }

    private void LateUpdate()
    {
        cameraController.Look(gameplayActions.look.ReadValue<Vector2>());
    }




   
}
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //
    //Propertie/parameters
    //
    [SerializeField]
    private PlayerMovement playerMovement;
    [SerializeField]
    private PlayerCameraController cameraController;
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
        playerInput = new SimpleControls();
        gameplayActions = playerInput.gameplay;

        gameplayActions.fire.performed += ctx => playerMovement.Fire(ctx);
        gameplayActions.jump.performed += ctx => playerMovement.Jump();

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
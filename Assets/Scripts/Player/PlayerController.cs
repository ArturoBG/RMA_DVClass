using UnityEngine;

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
    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerInput = new SimpleControls();
        gameplayActions = playerInput.gameplay;

        gameplayActions.fire.performed += ctx => playerMovement.Fire(ctx);
    }

    private void OnEnable()
    {
        Debug.Log("OnEnable");
        gameplayActions.Enable();
    }

    private void OnDisable()
    {
        Debug.Log("OnDisable");
        gameplayActions.Disable();
    }

    public void Start()
    {
        Debug.Log("this is an Start");
    }

    // Update is called once per frame
    private void Update()
    {
        Debug.Log("this is an Update");
        playerMovement.Move(gameplayActions.move.ReadValue<Vector2>());
    }
}
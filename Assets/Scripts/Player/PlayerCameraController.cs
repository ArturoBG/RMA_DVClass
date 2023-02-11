using UnityEngine;

public class PlayerCameraController : MonoBehaviour
{
    private Camera firstPersonCamera;

    [SerializeField]
    private float xRotation = 0f;

    [SerializeField]
    private float xSensitivity = 10f;

    [SerializeField]
    private float ySensitivity = 10f;

    [SerializeField]
    private float minX;

    [SerializeField] 
    private float maxX;

    private void Start()
    {
        firstPersonCamera = GetComponentInChildren<Camera>();
    }

    public void Look(Vector2 input)
    {
        float mouseX = input.x;
        float mouseY = input.y;

        //Debug.Log("input mouse x "+mouseX+ " y "+mouseY);

        //calculate camera rotation
        xRotation -= (mouseY * Time.deltaTime) * ySensitivity;
        xRotation = Mathf.Clamp(xRotation, minX, maxX);

        //rotate up or down
        firstPersonCamera.transform.localRotation = Quaternion.Euler( xRotation, 0f, 0f);

        //rotate left or right
        this.transform.Rotate( Vector3.up * (mouseX * Time.deltaTime) * xSensitivity );
    }


}
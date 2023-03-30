using Cinemachine;
using UnityEngine;

public class PlayerCameraController : MonoBehaviour
{
    [Header("FirstPersonCamera Settings")]
    [SerializeField]
    private CinemachineVirtualCamera firstPersonCamera;

    [SerializeField]
    private GameObject canvasFPS;

    [SerializeField]
    private bool fpsCam = true;

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

    [Header("ThirdPersonCamera Settings")]
    [SerializeField]
    private CinemachineVirtualCamera thirdPersonCamera;

    [SerializeField]
    private GameObject canvasTPS;

    [SerializeField]
    private Transform camFollow;

    [SerializeField]
    private float turnSpeed;

    private void Start()
    {
        //init in fps
        thirdPersonCamera.Priority = 0;
        canvasTPS.SetActive(false);
        firstPersonCamera.Priority = 10;
        canvasFPS.SetActive(true);
    }

    public void Look(Vector2 input)
    {
        if (fpsCam) //fps
        {
            //change priorities
            thirdPersonCamera.Priority = 0;
            canvasTPS.SetActive(false);
            firstPersonCamera.Priority = 10;
            canvasFPS.SetActive(true);
            float mouseX = input.x;
            float mouseY = input.y;

            //Debug.Log("input mouse x "+mouseX+ " y "+mouseY);

            //calculate camera rotation
            xRotation -= (mouseY * Time.deltaTime) * ySensitivity;
            xRotation = Mathf.Clamp(xRotation, minX, maxX);

            //rotate up or down
            firstPersonCamera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

            //rotate left or right
            this.transform.Rotate(Vector3.up * (mouseX * Time.deltaTime) * xSensitivity);
        }
        else //thirdpersoncamera
        {
            thirdPersonCamera.Priority = 10;
            canvasTPS.SetActive(true);
            firstPersonCamera.Priority = 0;
            canvasFPS.SetActive(false);

            //rotation from input
            var rotInput = new Vector2(input.x, input.y);
            var rot = transform.eulerAngles;

            Debug.Log($"RotInput {input.x}, {input.y}");
            Debug.Log($"Rot {rot.x}, {rot.y}, {rot.z}");

            rot.y += rotInput.x * turnSpeed;
            transform.rotation = Quaternion.Euler(rot);
            //

            rot = camFollow.localRotation.eulerAngles;
            rot.x -= rotInput.y * turnSpeed;
            if (rot.x > 180)
            {
                rot.x -= 360;
            }
            rot.x = Mathf.Clamp(rot.x, minX, maxX);
            camFollow.localRotation = Quaternion.Euler(rot);

        }
    }

    public void SwitchCamera()
    {
        if (fpsCam)
        {
            fpsCam = false;
        }
        else
        {
            fpsCam = true;
        }
    }
}
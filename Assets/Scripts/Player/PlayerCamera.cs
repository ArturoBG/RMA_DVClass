using Cinemachine;
using UnityEngine;
using UnityEngine.Windows;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera MainCamera;
    

    [Header("TPCam")]
    [SerializeField]
    public Transform InvisibleCameraOrigin;
    
    [SerializeField]
    private float turnSpeed;


    [SerializeField]
    private float xRotation;

    [SerializeField] 
    private float ySensitivity = 1f;
    [SerializeField] 
    private float xSensitivity = 1f;

    [SerializeField]
    private float minX = -60f;

    [SerializeField]
    private float maxX = 60f;

    public void ProcessLook(Vector2 input)
    {
        ThirdPersonCamera(input);        
    }

    public void ThirdPersonCamera(Vector2 input)
    {
        //rotation from input
        var rotInput = new Vector2(input.x, input.y);
        var rot = transform.eulerAngles;
        rot.y += rotInput.x * turnSpeed;
        transform.rotation = Quaternion.Euler(rot);

        if (InvisibleCameraOrigin != null)
        {
            rot = InvisibleCameraOrigin.localRotation.eulerAngles;
            rot.x -= rotInput.y * turnSpeed;
            if (rot.x > 180)
                rot.x -= 360;
            rot.x = Mathf.Clamp(rot.x, minX, maxX);
            InvisibleCameraOrigin.localRotation = Quaternion.Euler(rot);
        }
    }

    public void FIrstPersonCamera(Vector2 input)
    {
        Debug.Log("Camera {" + input.x + "}. {" + input.y + "}");
        float mouseX = input.x;
        float mouseY = input.y;

        xRotation -= (mouseY * Time.deltaTime) * ySensitivity;
        xRotation = Mathf.Clamp(xRotation, minX, maxX);

        MainCamera.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        transform.Rotate(Vector3.up * (mouseX * Time.deltaTime) * xSensitivity);
    }
}

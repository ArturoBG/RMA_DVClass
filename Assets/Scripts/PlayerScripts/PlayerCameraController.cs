using Cinemachine;
using UnityEngine;

namespace Scripts.PlayerScripts
{
    public class PlayerCameraController : MonoBehaviour
    {
        [SerializeField]
        private Camera MainCamera;

        public Transform InvisibleCameraOrigin;
        //second part
        //[SerializeField]
        //private GameObject thirdPersonCamera;

        [SerializeField]
        private bool fpsCam = true;

        [Header("FPCam")]
        [SerializeField]
        private CinemachineVirtualCamera firstPersonCam;

        [SerializeField]
        private GameObject firstPersonCanvas;

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

        [Header("TPCam")]
        [SerializeField]
        private float turnSpeed;

        [SerializeField]
        private float StrafeSpeed = 0.1f;

        [SerializeField]
        private float currentStrafeSpeed;

        [SerializeField]
        private CinemachineVirtualCamera thirdPersonCam;

        [SerializeField]
        private GameObject thirdPersonCanvas;

        private void Start()
        {
            //default as first person
            firstPersonCam.Priority = 10;
            thirdPersonCam.Priority = 0;
            thirdPersonCanvas.SetActive(false);
            firstPersonCanvas.SetActive(true);
        }

        public void ProcessLook(Vector2 input)
        {
            if (fpsCam)
            {
                //change priority
                firstPersonCam.Priority = 10;
                thirdPersonCam.Priority = 0;
                thirdPersonCanvas.SetActive(false);
                firstPersonCanvas.SetActive(true);
                //first part
                float mouseX = input.x;
                float mouseY = input.y;
                //calculate camera rotation
                xRotation -= (mouseY * Time.deltaTime) * ySensitivity;
                xRotation = Mathf.Clamp(xRotation, minX, maxX);

                //apply to camera transform
                firstPersonCam.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
                //rotate left or right
                transform.Rotate(Vector3.up * (mouseX * Time.deltaTime) * xSensitivity);
            }//second part
            else
            {
                //change priority
                firstPersonCam.Priority = 0;
                thirdPersonCam.Priority = 10;
                thirdPersonCanvas.SetActive(true);
                firstPersonCanvas.SetActive(false);
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
        }

        public void SwitchCamera()
        {
            Debug.Log("switch camera");
            if (fpsCam)
                fpsCam = false;
            else
                fpsCam = true;
        }
    }
}
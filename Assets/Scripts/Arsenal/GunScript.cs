using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    [SerializeField]
    private Transform rightHReference;
    [SerializeField]
    private Transform leftHReference;
    [SerializeField]
    private Transform gunRightHandReference;
    [SerializeField]
    private Transform gunLeftHandReference;

    public GameObject gunReference;
    public Transform muzzleReference;

    public void SetNewReferencesInGun()
    {
        Debug.Log("change references");

        gunReference.SetActive(true);
        rightHReference.localPosition = gunRightHandReference.localPosition;
        leftHReference.localPosition = gunLeftHandReference.localPosition;

    }

}

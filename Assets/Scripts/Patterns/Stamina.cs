using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stamina : MonoBehaviour
{
    [SerializeField]
    private float staminaLevel = 100f;

    private void OnEnable()
    {
        GetComponent<Level>().CallingLevelFirstDelegate += ResetStamina;
    }

    private void OnDisable()
    {
        GetComponent<Level>().CallingLevelFirstDelegate -= ResetStamina;
    }

    public void ResetStamina()
    {
        Debug.Log("reset stamina");
        staminaLevel = 100;
    }
     

}

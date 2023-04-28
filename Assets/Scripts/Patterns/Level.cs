using System.Collections;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField]
    private bool levelUp = false;

    public delegate void LevelDelegateAction();

    public event LevelDelegateAction CallingLevelFirstDelegate;

    //On level up the health value shall be 100 again
    private void LevelUp()
    {
        //code here
        CallingLevelFirstDelegate();
    }

    private void Update()
    {
        if (levelUp)
        {
            StartCoroutine(counterRoutine());
            levelUp = false;
        }
    }

    private IEnumerator counterRoutine()
    {
        yield return new WaitForSeconds(1f);
        LevelUp();
    }
}
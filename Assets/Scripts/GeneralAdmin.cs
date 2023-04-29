using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Scripts.PlayerScripts;
using UnityEngine.UI;

public class GeneralAdmin : MonoBehaviour
{
    public UIAdmin uiAdmin;
    //Timer 
    public float GameTime = 120f;
    //Player
    public PlayerController player;
    //UI
    public float scale = 0.1f;
    int score = 0;
    public TMP_Text timer;
    public TMP_Text messages;
    public TMP_Text scoreNum;


    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        player = FindObjectOfType<PlayerController>();
    }

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {   
        score = 0;
        timer.text = "" + GameTime;
        //DebugLog(""+valor decimal);
        StartCoroutine(initialMessagesCoroutine());
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {

    }

    IEnumerator initialMessagesCoroutine()
    {
        yield return new WaitForSeconds(1f);
        messages.text = "Level 1";
        yield return new WaitForSeconds(0.5f);
        messages.text = "Kill all enemies";
        yield return new WaitForSeconds(0.5f);
        messages.text = "3";
        yield return new WaitForSeconds(1f);
        messages.text = "2";
        yield return new WaitForSeconds(1f);
        messages.text = "1";
        yield return new WaitForSeconds(1f);
        //Launch the timer
        messages.text = "";
        yield return StartCoroutine(TimerCountdownCoroutine(GameTime));
        //
        messages.text = "Time's Up!";
        messages.gameObject.SetActive(false);
        // UI admin
        //restart level
        //load scene menu, level 2, level 1
    }

    private IEnumerator TimerCountdownCoroutine(float duration) 
    {
        yield return new WaitForFixedUpdate();
        float time = duration;
        while(duration > 0)
        {
            //TODO 
            time = time - Time.deltaTime * scale;
            timer.text = ""+ Mathf.RoundToInt(time);
            yield return null;
        }
 
    }   

    ///Score
    public void AddScore(int value)
    {
        //1 en 1
        //score = score + 1;
        
        //different values
        //score += value;

        scoreNum.text = ""+score;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



/// <summary>
///   Timer that counts down and then changes text to prompt player to continue to follow FW
/// </summary>
public class Timer : MonoBehaviour
{
    public float countdownTime;
    public float timeRemaining = 10;
    public bool timerIsRunning = false;
    public GameObject PlayerFollowPrompt;
    

    private void Start()
    {
        PlayerFollowPrompt.SetActive(false);
        resetTimer();      
    }
    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                PlayerFollowPrompt.SetActive(true);
                timeRemaining = 0;
                timerIsRunning = false;
            }
        }
    }
    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);      
    }

    public void StartTimer()  // call this when FM reaches waypoint
    {
        resetTimer();
        timerIsRunning = true;       
    }

    public void StopTimer()   // call this when player enters FW trigger
    {
        timerIsRunning = false;
    }

    public void resetTimer()
    {
        timeRemaining = countdownTime;
    }
}
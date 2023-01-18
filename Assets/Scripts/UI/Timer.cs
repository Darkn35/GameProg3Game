using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] private WinBehavior win;
    [SerializeField] private BackgroundMover background;

    public TextMeshProUGUI timerText;

    public float seconds, minutes, timeRemaining;

    private float maxTime, finalTime;

    public bool isTimeRunning;

    // Start is called before the first frame update
    void Start()
    {
        maxTime = timeRemaining;
        isTimeRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isTimeRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                //DisplayTime(timeRemaining);
            }
            else
            {
                Debug.Log("Time has run out.");
                win.Lose();
                timeRemaining = 0;
                isTimeRunning = false;
            }
        }
        //else if (!isTimeRunning && timeRemaining > 0)
        //{
        //    DisplayTime(maxTime - timeRemaining);
        //}
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        minutes = Mathf.FloorToInt(timeToDisplay / 60);
        seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        timerText.enabled = true;
    }
}

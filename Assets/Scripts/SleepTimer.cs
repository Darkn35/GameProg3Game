using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SleepTimer : MonoBehaviour
{
    [SerializeField] PlayerMovement Player;
    public Slider slider;
    public float sleepTime;
    private bool justLanded;

    // Start is called before the first frame update
    void Start()
    {
        slider.minValue = 0f;
        slider.maxValue = 10f;
        justLanded = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (justLanded)
        {
            sleepTime += Time.deltaTime;
        }
        slider.value = sleepTime;

        if (!Player.isMoving && justLanded)
        {
            StartTime();
        }
        else
        {
            sleepTime = 0f;
        }
    }
    public void StartTime()
    {
        justLanded = true;
    }

    public void ResetTime()
    {
        justLanded = false;
        sleepTime = 0f;
    }
}

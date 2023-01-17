using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SleepTimer : MonoBehaviour
{
    [SerializeField] private PlayerMovement player;
    [SerializeField] private WinBehavior winBehavior;
    public Slider slider;
    public float sleepTime;
    public float sleepTimeMultiplier;
    public float itemTimeMultiplier;
    public bool justLanded;
    private bool isGameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        slider.minValue = 0f;
        slider.maxValue = 10f;
        justLanded = false;
        sleepTimeMultiplier = 1f;
        itemTimeMultiplier = 1f;
    }

    // Update is called once per frame
    void Update()
    {

        slider.value = sleepTime;

        if (justLanded)
        {
            sleepTime = sleepTime + (Time.deltaTime * sleepTimeMultiplier * itemTimeMultiplier);
        }

        if (!player.isMoving && justLanded)
        {
            StartTime();
        }
        else
        {
            sleepTime = 0f;
        }

        if (slider.value == slider.maxValue && !isGameOver)
        {
            winBehavior.Win();
            isGameOver = true;
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

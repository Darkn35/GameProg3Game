using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseBehavior : MonoBehaviour
{
    public UIMenu uiMenu;
    // Start is called before the first frame update
    void Start()
    {
        if (Time.timeScale == 0.0f)
        {
            Time.timeScale = 1.0f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PauseTime()
    {
        uiMenu.pauseMenu.SetActive(true);
        Time.timeScale = 0.0f;
    }

    public void ResumeTime()
    {
        uiMenu.pauseMenu.SetActive(false);
        Time.timeScale = 1.0f;
    }
}

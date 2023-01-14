using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private PauseBehavior pause;
    public bool isPaused = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        InputCheck();
    }

    void InputCheck()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (!isPaused)
            {
                pause.PauseTime();
                isPaused = true;
            }
            else
            {
                pause.ResumeTime();
                isPaused = false;
            }
        }
    }
}

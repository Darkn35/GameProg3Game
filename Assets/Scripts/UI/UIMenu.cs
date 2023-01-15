using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMenu : MonoBehaviour
{
    [Header("Pause Menu Variables")]
    public GameObject pauseMenu;
    public PlayerInput playerInput;
    public PauseBehavior pauseBehavior;
    public WinBehavior winBehavior;

    [Header("UI Menu Variables")]
    public GameObject mainMenu;
    public GameObject menuAbout;
    public GameObject menuCredits;
    public GameObject menuSettings;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonFunction(string input)
    {
        switch (input)
        {
            case "pauseResume":
                {
                    playerInput.isPaused = false;
                    pauseMenu.SetActive(false);
                    pauseBehavior.ResumeTime();
                }
                break;
            case "pauseRetry":
                {
                    SceneManager.LoadScene(winBehavior.levelName);
                }
                break;
            case "pauseExit":
                {
                    pauseBehavior.ResumeTime();
                    SceneManager.LoadScene("MainMenu");
                }
                break;
            case "menuStart":
                {
                    SceneManager.LoadScene("SampleScene");
                }
                break;
            case "menuAbout":
                {
                    mainMenu.SetActive(false);
                    menuAbout.SetActive(true);
                }
                break;
            case "menuCredits":
                {
                    mainMenu.SetActive(false);
                    menuCredits.SetActive(true);
                }
                break;
            case "menuSettings":
                {
                    mainMenu.SetActive(false);
                    menuSettings.SetActive(true);
                }
                break;
            case "menuExit":
                {
                    Application.Quit();
                }
                break;
            case "back" : 
                {
                    if (menuAbout.activeInHierarchy)
                    {
                        menuAbout.SetActive(false);
                    }
                    else if (menuCredits.activeInHierarchy)
                    {
                        menuCredits.SetActive(false);
                    }
                    else if (menuSettings.activeInHierarchy)
                    {
                        menuSettings.SetActive(false);
                    }
                    mainMenu.SetActive(true);
                }
                break;
        }
    }
}

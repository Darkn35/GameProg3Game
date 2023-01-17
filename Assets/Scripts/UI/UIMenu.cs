using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMenu : MonoBehaviour
{
    [Header("Transition Animator")]
    public LevelLoader levelLoader;

    [Header("Pause Menu Variables")]
    public GameObject pauseMenu;
    public PlayerInput playerInput;
    public PauseBehavior pauseBehavior;
    public WinBehavior winBehavior;

    [Header("UI Menu Variables")]
    public GameObject mainMenu;
    public GameObject menuAboutPageOne;
    public GameObject menuAboutPageTwo;
    public GameObject menuCreditsPageOne;
    public GameObject menuCreditsPageTwo;
    public GameObject menuSettings;

    private ObjectSounds sounds;

    // Start is called before the first frame update
    void Start()
    {
        sounds = GetComponent<ObjectSounds>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonFunction(string input)
    {
        sounds.PlayAudioOnce(ClipName.ClickSFX);
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
                    playerInput.isPaused = false;
                    pauseBehavior.ResumeTime();
                    levelLoader.LoadNextLevel(winBehavior.levelName);
                }
                break;
            case "pauseExit":
                {
                    MusicPlayer.instance.FadeAudio(0f);
                    pauseBehavior.ResumeTime();
                    levelLoader.LoadNextLevel("MainMenu");
                }
                break;
            case "menuStart":
                {
                    MusicPlayer.instance.FadeAudio(0f);
                    levelLoader.LoadNextLevel("Level 1");
                }
                break;
            case "menuAbout":
                {
                    mainMenu.SetActive(false);
                    menuAboutPageOne.SetActive(true);
                }
                break;
            case "menuCredits":
                {
                    mainMenu.SetActive(false);
                    menuCreditsPageOne.SetActive(true);
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
            case "next":
                {
                    if (menuAboutPageOne.activeInHierarchy)
                    {
                        menuAboutPageTwo.SetActive(true);
                        menuAboutPageOne.SetActive(false);
                    }
                    else if (menuCreditsPageOne.activeInHierarchy)
                    {
                        menuCreditsPageTwo.SetActive(true);
                        menuCreditsPageOne.SetActive(false);
                    }
                }
                break;
            case "back":
                {
                    if (menuAboutPageOne.activeInHierarchy)
                    {
                        menuAboutPageOne.SetActive(false);
                    }
                    else if (menuAboutPageTwo.activeInHierarchy)
                    {
                        menuAboutPageTwo.SetActive(false);
                        menuAboutPageOne.SetActive(true);
                        break;
                    }
                    else if (menuCreditsPageOne.activeInHierarchy)
                    {
                        menuCreditsPageOne.SetActive(false);
                    }
                    else if (menuCreditsPageTwo.activeInHierarchy)
                    {
                        menuCreditsPageTwo.SetActive(false);
                        menuCreditsPageOne.SetActive(true);
                        break;
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinBehavior : MonoBehaviour
{
    public GameObject levelWinText;
    public GameObject levelLoseText;
    public string nextLevelName;
    public string levelName;
    public float seconds;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Win()
    {
        levelWinText.SetActive(true);
        //Invoke("GoToNextLevel", 2);
        StartCoroutine(TimeDelay(seconds, nextLevelName));
    }

    public void Lose()
    {
        levelLoseText.SetActive(true);
        //Invoke("GoToNextLevel", 2);
        StartCoroutine(TimeDelay(seconds, levelName));
    }

    IEnumerator TimeDelay(float secs, string level)
    {
        yield return new WaitForSeconds(secs);
        SceneManager.LoadScene(level);

    }
}

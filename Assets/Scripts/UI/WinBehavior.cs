using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinBehavior : MonoBehaviour
{
    public GameObject levelWinText;
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
        StartCoroutine(TimeDelay(seconds));
    }

    IEnumerator TimeDelay(float secs)
    {
        yield return new WaitForSeconds(secs);
        GoToNextLevel();
    }

    void GoToNextLevel()
    {
        SceneManager.LoadScene(levelName);
        Debug.Log("yuor did it!");
    }
}

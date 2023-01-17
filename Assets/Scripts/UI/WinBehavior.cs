using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinBehavior : MonoBehaviour
{
    public LevelLoader levelLoader;
    public Timer timer;
    public GameObject levelWinText;
    public GameObject levelLoseText;
    public string nextLevelName;
    public string levelName;
    public float seconds;

    private ObjectSounds sound;

    // Start is called before the first frame update
    void Start()
    {
        if (MusicPlayer.instance.sounds.audioSource.volume < 1)
        {
            MusicPlayer.instance.FadeAudio(1f);
        }

        sound = GetComponent<ObjectSounds>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Win()
    {
        timer.isTimeRunning = false;
        levelWinText.SetActive(true);
        StartCoroutine(TimeDelay(seconds, nextLevelName, true));
    }

    public void Lose()
    {
        levelLoseText.SetActive(true);
        StartCoroutine(TimeDelay(seconds, levelName, false));
    }

    IEnumerator TimeDelay(float secs, string level, bool isWin)
    {
        MusicPlayer.instance.FadeAudio(0.25f);

        if (isWin)
            sound.PlayAudioOnce(ClipName.WinSFX);
        else
            sound.PlayAudioOnce(ClipName.LoseSFX);

        yield return new WaitForSeconds(secs);
        levelLoader.LoadNextLevel(level);
    }
}

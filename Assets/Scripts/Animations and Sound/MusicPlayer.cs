using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour
{
    public ObjectSounds sounds;
    private bool isInGame = false;

    public float fadeDuration;

    public static MusicPlayer instance = null;

    // Start is called before the first frame update

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            GameObject.DontDestroyOnLoad(gameObject);
            sounds = GetComponent<ObjectSounds>();
        }
    }

    void Start()
    {
        sounds.PlayAudioLoop(ClipName.MainMenuMusic);
    }

    private void FixedUpdate()
    {
        SceneManager.activeSceneChanged += ChangedActiveScene;
    }

    private void ChangedActiveScene(Scene current, Scene next)
    {
        current = SceneManager.GetActiveScene();
        string currentName = current.name;


        if (currentName == "MainMenu")
        {
            sounds.PlayAudioLoop(ClipName.MainMenuMusic);
            StartCoroutine(StartFade(sounds.audioSource, fadeDuration, 1));
            isInGame = false;
        }
        else
        {
            if (!isInGame)
            {
                sounds.PlayAudioLoop(ClipName.GameMusic);
                StartCoroutine(StartFade(sounds.audioSource, fadeDuration, 1));
                isInGame = true;
            }
        }
    }

    public void FadeAudio(float targetVolume)
    {
        StartCoroutine(StartFade(sounds.audioSource, fadeDuration, targetVolume));
    }

    private static IEnumerator StartFade(AudioSource audio, float duration, float targetVolume)
    {
        float currentTime = 0;
        float start = audio.volume;
        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            audio.volume = Mathf.Lerp(start, targetVolume, currentTime / duration);
            yield return null;
        }
        yield break;
    }
}

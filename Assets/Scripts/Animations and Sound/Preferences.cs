using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Preferences : MonoBehaviour
{
    public static Preferences instance = null;

    [Header("Sound Settings")]
    public float masterSliderValue;
    public float musicSliderValue;
    public float effectsSliderValue;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            masterSliderValue = 1f;
            musicSliderValue = 1f;
            effectsSliderValue = 1f;
            GameObject.DontDestroyOnLoad(gameObject);
        }
    }

    public void GetSoundSettings(Slider master, Slider music, Slider effects)
    {
        masterSliderValue = master.value;
        musicSliderValue = music.value;
        effectsSliderValue = effects.value;
    }

    public void SetSoundSettings(Slider master, Slider music, Slider effects)
    {
        master.value = masterSliderValue;
        music.value = musicSliderValue;
        effects.value = effectsSliderValue;
    }
}

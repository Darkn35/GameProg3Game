using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;

public class MasterAudioMixer : MonoBehaviour
{
    public AudioMixer mixer;

    [Header("Slider GameObjects")]
    public Slider masterSlider;
    public Slider musicSlider;
    public Slider effectsSlider;

    [Header("Text Label GameObjects")]
    public TextMeshProUGUI masterLabel;
    public TextMeshProUGUI musicLabel;
    public TextMeshProUGUI effectsLabel;

    private void Start()
    {
        Preferences.instance.SetSoundSettings(masterSlider, musicSlider, effectsSlider);
        
        SetMasterVolume(masterSlider.value);
        SetMusicVolume(musicSlider.value);
        SetEffectsVolume(effectsSlider.value);

        masterSlider.onValueChanged.AddListener(delegate
        {
            Preferences.instance.GetSoundSettings(masterSlider, musicSlider, effectsSlider);
            SetMasterVolume(masterSlider.value);
        });

        musicSlider.onValueChanged.AddListener(delegate
        {
            Preferences.instance.GetSoundSettings(masterSlider, musicSlider, effectsSlider);
            SetMusicVolume(musicSlider.value);
        });

        effectsSlider.onValueChanged.AddListener(delegate
        {
            Preferences.instance.GetSoundSettings(masterSlider, musicSlider, effectsSlider);
            SetEffectsVolume(effectsSlider.value);
        });
    }

    public void SetMasterVolume(float value)
    {
        mixer.SetFloat("Master", Mathf.Log(value) * 20f);
        masterLabel.text = Mathf.Round(value * 100.0f).ToString() + "%";
    }
    public void SetMusicVolume(float value)
    {
        mixer.SetFloat("Music", Mathf.Log(value) * 20f);
        musicLabel.text = Mathf.Round(value * 100.0f).ToString() + "%";
    }

    public void SetEffectsVolume(float value)
    {
        mixer.SetFloat("Effects", Mathf.Log(value) * 20f);
        effectsLabel.text = Mathf.Round(value * 100.0f).ToString() + "%";
    }
}

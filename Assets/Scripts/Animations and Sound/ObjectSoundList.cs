using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ClipName
{
    MainMenuMusic, GameMusic, ObjectFell,
    WinSFX, LoseSFX, ClickSFX, FlapWings,
    BirdPredatorSFX, ScaredSFX, NegotiationSuccess,

}

public class ObjectSoundList : MonoBehaviour
{
    public AudioClip mainMenuMusic;
    public AudioClip gameMusic;
    public AudioClip objectFell;
    public AudioClip winSFX;
    public AudioClip loseSFX;
    public AudioClip clickSFX;
    public AudioClip flapWings;
    public AudioClip birdPredatorSFX;
    public AudioClip scaredSFX;
    public AudioClip negotiationSuccess;

    public static ObjectSoundList instance = null;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            GameObject.DontDestroyOnLoad(gameObject);
        }
    }

    public AudioClip FindAudioClip(ClipName name)
    {
        switch (name)
        {
            case ClipName.MainMenuMusic:
                {
                    return mainMenuMusic;
                }
            case ClipName.GameMusic:
                {
                    return gameMusic;
                }
            case ClipName.ObjectFell:
                {
                    return objectFell;
                }
            case ClipName.WinSFX:
                {
                    return winSFX;
                }
            case ClipName.LoseSFX:
                {
                    return loseSFX;
                }
            case ClipName.ClickSFX:
                {
                    return clickSFX;
                }
            case ClipName.FlapWings:
                {
                    return flapWings;
                }
            case ClipName.BirdPredatorSFX:
                {
                    return birdPredatorSFX;
                }
            case ClipName.ScaredSFX:
                {
                    return scaredSFX;
                }
            case ClipName.NegotiationSuccess:
                {
                    return negotiationSuccess;
                }
        }
        
        return null;
    }
}

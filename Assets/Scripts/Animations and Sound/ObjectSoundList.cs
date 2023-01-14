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
    public AudioClip nameAudioClip;
    public AudioClip jump;
    public static ObjectSoundList instance;

    void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public AudioClip FindAudioClip(ClipName name)
    {
        switch (name)
        {
            case ClipName.MainMenuMusic:
                {
                    return nameAudioClip;
                }
        }
        
        return null;
    }
}

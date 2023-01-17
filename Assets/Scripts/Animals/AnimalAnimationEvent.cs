using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalAnimationEvent : MonoBehaviour
{
    private ObjectSounds sounds;

    private void Start()
    {
        sounds = GetComponent<ObjectSounds>();
    }

    public void ScreechSFX()
    {
        sounds.PlayAudioOnce(ClipName.BirdPredatorSFX);
    }
}

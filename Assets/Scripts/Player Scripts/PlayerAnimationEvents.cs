using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationEvents : MonoBehaviour
{
    private ObjectSounds sounds;

    private void Start()
    {
        sounds = GetComponent<ObjectSounds>();
    }

    public void FlapWings()
    {
        sounds.PlayAudioOnce(ClipName.FlapWings);
    }

    public void ScaredSFX()
    {
        sounds.audioSource.volume = 0.55f;
        sounds.PlayAudioOnce(ClipName.ScaredSFX);
    }

    public void StopAudio()
    {
        sounds.audioSource.Stop();
    }

    public void ResetVolumeValues()
    {
        sounds.audioSource.volume = 1f;
    }

    public void ScaredAnimLeft()
    {
        this.gameObject.GetComponent<Transform>().Translate(-0.05f, 0, 0);
    }

    public void ScaredAnimRight()
    {
        this.gameObject.GetComponent<Transform>().Translate(+0.05f, 0, 0);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSounds : MonoBehaviour
{
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayAudioOnce(ClipName name)
    {
        audioSource.loop = false;
        audioSource.PlayOneShot(ObjectSoundList.instance.FindAudioClip(name));
    }

    public void PlayAudioLoop(ClipName name)
    {
        audioSource.Stop();
        audioSource.loop = true;
        audioSource.clip = ObjectSoundList.instance.FindAudioClip(name);
        audioSource.Play();
    }
}

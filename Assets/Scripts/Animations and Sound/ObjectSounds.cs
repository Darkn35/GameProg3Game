using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSounds : MonoBehaviour
{
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayAudioOnce(ClipName name)
    {
        audioSource.PlayOneShot(ObjectSoundList.instance.FindAudioClip(name));
    }
}

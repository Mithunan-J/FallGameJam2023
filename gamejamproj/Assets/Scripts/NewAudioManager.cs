using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewAudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public Sound[] goatSounds;
    public AudioClip goatThrown;
    public AudioClip demonDeath;

    AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoatThrownAudio()
    {
        audioSource.clip = goatThrown;
        audioSource.Play();
    }
}

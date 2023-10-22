using UnityEngine.Audio;
using UnityEngine;
using System;


public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public Sound[] goatSounds;




    void Awake(){
        foreach (Sound s in sounds){
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;


            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }
    }

    AudioSource audioData;

    void Start()
    {
        audioData = GetComponent<AudioSource>();
        audioData.Play(0);
        Debug.Log("started");
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sounds => sounds.name == name);
        s.source.Play();
    }

    public void PlayGoatSound(){
        //Sound s = goatSounds[0];
        //s.source.Play();

        Play("DemonDeath1");
    }
    
}

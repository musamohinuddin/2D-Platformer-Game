using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;
    public static SoundManager Instance { get { return instance;}}

    public AudioSource soundEffect;
    public AudioSource SoundMusic;
   
    public SoundType[] Sounds;

    

    private void Awake() 
    {
        PlayMusic(global::Sounds.BgMusic);
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else
        {
            Destroy(gameObject);
        }
    }

    public void Play(Sounds sound)
    {
        AudioClip clip = getSoundClip(sound);
        if(clip != null)
        {
            soundEffect.PlayOneShot(clip);
        } else 
        {
            Debug.LogError("Clip not found for sound type:" + sound);
        }
    }

    private AudioClip getSoundClip(Sounds sound)
    {
        SoundType item = Array.Find(Sounds, i => i.soundType == sound);
        if(item != null)
            return item.soundClip;
        return null;    
    }
    
    
    // Start is called before the first frame update
    void Start()
    {
       PlayMusic(global::Sounds.BgMusic);
    }

    public void PlayMusic(Sounds sound)
    {
        AudioClip clip = getSoundClip(sound);
        if(clip != null)
        {
            SoundMusic.clip = clip;
            SoundMusic.loop = true;
            SoundMusic.volume = 0.5f;
            SoundMusic.Play();
            
            

        } else
        {
            Debug.LogError("Clip not found for sound type:" + sound);
        }
    }
   
   

    // Update is called once per frame
    void Update()
    {
        
    }
}


public enum Sounds
{
    ButtonClick,
    BgMusic,
    PlayerRun,
    PlayerDeath,
    KeyCollected,
    LevelStart,
    LevelComplete,
    PlayerJump,
}


[Serializable]
public class SoundType 
{
    public Sounds soundType;
    public AudioClip soundClip;
}
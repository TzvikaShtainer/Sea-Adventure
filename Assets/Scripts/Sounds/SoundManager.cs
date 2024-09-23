using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using FMOD.Studio;
using UnityEngine;
using FMODUnity;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance{get; private set;}

    private EventInstance bgMusicEventInstance;
    
    [Range(0, 1)]
    public float bgMusicVolume = 1;
    
    [Range(0, 1)]
    public float sfxVolume = 1;

    private Bus musicBus;
    private Bus sfxBus;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            //Debug.Log(gameObject.name + " is set as the singleton instance.");
        }
        else
        {
            //Debug.Log(gameObject.name + " is being destroyed because a singleton instance already exists.");
            Destroy(gameObject);
        }
        
        musicBus = RuntimeManager.GetBus("bus:/Music");
        sfxBus = RuntimeManager.GetBus("bus:/SFX");
    }
    
    private void OnDestroy()
    {
        Debug.Log(gameObject.name + " has been destroyed.");
    }
    

    private void Start()
    {
        InitBgMusic(FModEvents.instance.bgMusic);
    }

    private void Update()
    {
        musicBus.setVolume(bgMusicVolume);
        sfxBus.setVolume(sfxVolume);
        
        Debug.Log(gameObject.name + " is still alive.");
    }

    private void InitBgMusic(EventReference bgMusicEventReference)
    {
        bgMusicEventInstance = CreateInstance(bgMusicEventReference);
        bgMusicEventInstance.start();
    }

    public EventInstance CreateInstance(EventReference eventReference)
    {
        EventInstance eventInstance = RuntimeManager.CreateInstance(eventReference);
        return eventInstance;
    }
    public void PlayOneShot(EventReference sound, Vector3 worldPos)
    {
        RuntimeManager.PlayOneShot(sound, worldPos);
    }
}

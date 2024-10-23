using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using FMOD.Studio;
using UnityEngine;
using FMODUnity;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance{get; private set;}

    private EventInstance bgMusicEventInstance;
    
    [Range(0, 1)] public float bgMusicVolume = 1;
    [Range(0, 1)] public float sfxVolume = 1;

    private Bus musicBus;
    private Bus sfxBus;
    
    [SerializeField] private static bool isMusicPlaying;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        InitializeBuses();
        LoadVolumeSettings();
    }

    private void InitializeBuses()
    {
        musicBus = RuntimeManager.GetBus("bus:/Music");
        sfxBus = RuntimeManager.GetBus("bus:/SFX");
    }
    
    private void LoadVolumeSettings()
    {
        bgMusicVolume = PlayerPrefs.GetFloat("MusicVolume", 1f);
        sfxVolume = PlayerPrefs.GetFloat("SFXVolume", 1f);
    }
    
    private void Start()
    {
        PlayBgMusic(FModEvents.Instance.BgMusic);
    }

    private void Update()
    {
        musicBus.setVolume(bgMusicVolume);
        sfxBus.setVolume(sfxVolume);
    }

    private void PlayBgMusic(EventReference bgMusicEventReference)
    {
        if (isMusicPlaying)
        {
            //Debug.Log("Background music is already playing.");
            return;
        }

        isMusicPlaying = true; 
        
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
    
    public void PlayClickSound()
    {
        PlayOneShot(FModEvents.Instance.BtnClicked, transform.position);
    }
}

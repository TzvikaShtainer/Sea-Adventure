using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
   public enum VolumeType
   {
      Music,
      SFX,
   }
   
   [Header("Type:")]
   [SerializeField] private VolumeType volumeType;
   
   [SerializeField] private Slider volumeSlider;

   private void Start()
    {
        InitializeSlider();
        volumeSlider.onValueChanged.AddListener(OnSliderValueChanged);
    }

    private void OnDestroy()
    {
        volumeSlider.onValueChanged.RemoveListener(OnSliderValueChanged); 
    }

    private void InitializeSlider()
    {
        switch (volumeType)
        {
            case VolumeType.Music:
                float savedMusicVolume = PlayerPrefs.GetFloat("MusicVolume", 1f); 
                volumeSlider.value = savedMusicVolume;
                SoundManager.Instance.bgMusicVolume = savedMusicVolume;
                break;

            case VolumeType.SFX:
                float savedSFXVolume = PlayerPrefs.GetFloat("SFXVolume", 1f); 
                volumeSlider.value = savedSFXVolume;
                SoundManager.Instance.sfxVolume = savedSFXVolume; 
                break;
        }
    }

    private void OnSliderValueChanged(float value)
    {

        switch (volumeType)
        {
            case VolumeType.Music:
                SoundManager.Instance.bgMusicVolume = value;
                PlayerPrefs.SetFloat("MusicVolume", value);
                break;

            case VolumeType.SFX:
                SoundManager.Instance.sfxVolume = value;
                PlayerPrefs.SetFloat("SFXVolume", value);
                break;
        }

        PlayerPrefs.Save();
    }

    private void Update()
    {
        switch (volumeType)
        {
            case VolumeType.Music:
                if (volumeSlider.value != SoundManager.Instance.bgMusicVolume)
                    volumeSlider.value = SoundManager.Instance.bgMusicVolume;
                break;

            case VolumeType.SFX:
                if (volumeSlider.value != SoundManager.Instance.sfxVolume)
                    volumeSlider.value = SoundManager.Instance.sfxVolume;
                break;
        }
    }
}

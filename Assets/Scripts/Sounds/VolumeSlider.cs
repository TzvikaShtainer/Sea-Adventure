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

   private void Awake()
   {
      //volumeSlider = this.GetComponentInChildren<Slider>();   
   }

   private void Update()
   {
      switch (volumeType)
      {
         case VolumeType.Music:
            volumeSlider.value =  SoundManager.instance.bgMusicVolume;
            break;
         case VolumeType.SFX:
            volumeSlider.value = SoundManager.instance.sfxVolume;
            break;
      }
   }

   public void OnSliderValueChanged()
   {
      switch (volumeType)
      {
         case VolumeType.Music:
            SoundManager.instance.bgMusicVolume = volumeSlider.value;
            break;
         case VolumeType.SFX:
            SoundManager.instance.sfxVolume = volumeSlider.value;
            break;
      }
   }
}

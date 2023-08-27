using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class SettingPanel : BasePopup
{
    public AudioMixer mixer;
    public Slider soundSlider;
    public Slider musicSlider;
    public TMP_Text soundPercentage;
    public TMP_Text musicPercentage;
    private void Start()
    {
        if (mixer.GetFloat("SoundVolume", out float soundVolume))
        {
            soundSlider.value = soundVolume;
        }
        if (mixer.GetFloat("MusicVolume", out float musicVolume))
        {
            musicSlider.value = musicVolume;
        }
    }
    public void OnSoundVolumeChanged(float value)
    {
        mixer.SetFloat("SoundVolume", value);
        float percentage = value + 80;
        soundPercentage.text = $"{(int)percentage}%";
    }
    public void OnMusicVolumeChanged(float value)
    {
        mixer.SetFloat("MusicVolume", value);
        float percentage = value + 80;
        musicPercentage.text = $"{(int)percentage}%";
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    [SerializeField] AudioMixer _audioMixer;

    [SerializeField] Slider _masterVolumeSlider;
    [SerializeField] Slider _musicVolumeSlider;
    [SerializeField] Slider _SFXSlider;
    [SerializeField] Slider _brightnessSlider;

    [SerializeField] Image _blackOverlay;

    [SerializeField] GameObject _settingsPage;

    private void Awake()
    {
        AudioPreference();
        BrightnessPreference();
    }

    public void MasterVolume()
    {
        _audioMixer.SetFloat("Master", _masterVolumeSlider.value);
    }

    public void MusicVolume()
    {
        _audioMixer.SetFloat("Music", _musicVolumeSlider.value);
    } 

    public void SFXVolume()
    {
        _audioMixer.SetFloat("SFX", _SFXSlider.value);
    }

    public void AudioPreference()
    {
        PlayerPrefs.GetFloat("Master");
        PlayerPrefs.GetFloat("Music");
        PlayerPrefs.GetFloat("SFX");
    }

    public void BrightnessLevels()
    {
        var tempColor = _blackOverlay.color;
        tempColor.a = _brightnessSlider.value;
        _blackOverlay.color = tempColor;

        PlayerPrefs.SetFloat("BrightnessSet", _brightnessSlider.value);
    }

    private void BrightnessPreference()
    {
        _brightnessSlider.value = PlayerPrefs.GetFloat("BrightnessSet");
    }

    public void CloseSettings()
    {
        _settingsPage.SetActive(false);
        PlayerPrefs.Save();
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class volumeManager : MonoBehaviour
{

    public AudioSource backgroundSound;

    public AudioSource collectableSound;
    public AudioSource jumpSound;
    public AudioSource landingSound;
    public AudioSource deathSound;

    public AudioSource buttonSound;

    public Slider musicVolumeSlider;
    public Slider SFXVolumeSlider;

    private float theMusicVolumeValue;
    private float theSFXVolumeSliderValue;

    public Text musicVolumeText;
    public Text SFXVolumeText;

	void Start()
	{
        musicVolumeSlider.value = 0.75f;
        SFXVolumeSlider.value = 0.75f;
	}
		
    void Update()
    {
        theMusicVolumeValue = musicVolumeSlider.value;
        theSFXVolumeSliderValue = SFXVolumeSlider.value;

        musicVolumeText.text = "Music volume: " + Mathf.Round(theMusicVolumeValue * 100) + "%";
        SFXVolumeText.text = "SFX volume: " + Mathf.Round(theSFXVolumeSliderValue * 100) + "%";
    }

    public void ChangeMusicVolume()
    {
        backgroundSound.volume = musicVolumeSlider.value;
    }

    public void ChangeSFXVolume()
    {
        collectableSound.volume = SFXVolumeSlider.value;
        jumpSound.volume = SFXVolumeSlider.value;
        landingSound.volume = SFXVolumeSlider.value;
        deathSound.volume = SFXVolumeSlider.value;
        buttonSound.volume = SFXVolumeSlider.value;
    }

}

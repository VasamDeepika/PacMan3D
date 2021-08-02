using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionsManager : MonoBehaviour
{
    public Slider volumeSlider;
    public Slider difficultySlider;

    private AudioManager audioManager;

    private void Start()
    {
        volumeSlider.value = PlayerPrefsManager.GetMasterVolume();
        difficultySlider.value = PlayerPrefsManager.GetDifficulty();
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }
    private void Update()
    {
        audioManager.SetVolume("BackGround", volumeSlider.value);
    }
    public void SaveAndExit()
    {
        PlayerPrefsManager.SetMasterVolume(volumeSlider.value);
        PlayerPrefsManager.SetDifficulty(difficultySlider.value);
    }
    public void SetDefaults()
    {
        volumeSlider.value = 0.5f;
        difficultySlider.value = 0.5f;
    }
}

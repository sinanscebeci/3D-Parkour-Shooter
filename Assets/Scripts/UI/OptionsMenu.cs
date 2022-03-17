using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;


public class OptionsMenu : MonoBehaviour
{
    public AudioMixer audiomixer;
    private bool fullscreenOnOff;
    

    public void SetResolution(int resIndex)
    {
        if (resIndex == 0)
            Screen.SetResolution(1920, 1080, fullscreenOnOff);
        if (resIndex == 1)
            Screen.SetResolution(1280, 720, fullscreenOnOff);
    }
    public void SetQuality (int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
    public void SetFullscreen (bool fullscreenEnabled)
    {
        Screen.fullScreen = fullscreenEnabled;
        fullscreenOnOff = fullscreenEnabled;
    }
    public void SetSensitivity (float sensValue)
    {
        PlayerPrefs.SetFloat("MouseSensitivity", sensValue);

        if(GameObject.FindGameObjectWithTag("Player") != null)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().MouseSensitivity = sensValue;
        }
    }
    public void BacktoMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void SetMasterVolume(float value)
    {
        audiomixer.SetFloat("MasterVolume", value);
        PlayerPrefs.SetFloat("MasterVolume", value);
    }

    public void SetMusicVolume(float value)
    {
        audiomixer.SetFloat("MusicVolume", value);
        PlayerPrefs.SetFloat("MusicVolume", value);
    }

    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Startup : MonoBehaviour
{
    public Slider mouse, master, music;
    
    private void Awake()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().MouseSensitivity = PlayerPrefs.GetFloat("MouseSensitivity", 200f);

        mouse.value = PlayerPrefs.GetFloat("MouseSensitivity", 200f);

        master.value = PlayerPrefs.GetFloat("MasterVolume", 60);

        music.value = PlayerPrefs.GetFloat("MusicVolume", 60);
    }
}

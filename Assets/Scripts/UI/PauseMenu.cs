using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    private bool gamePaused;

    public GameObject pauseMenu, player, pistol;

    

    public void Awake()
    {
        Time.timeScale = 1;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) & player.GetComponent<PlayerManager>().getAliveBool())
        {
            if (!gamePaused)
            {
                Pause();
            }
            else
            {
                Resume();
            }
        }
    }
    public void Pause()
    {
        //Stop Time
        Time.timeScale = 0;
        
        //Open Pause Menu
        pauseMenu.SetActive(true);

        //Disable Player Movement and Pistol
        player.GetComponent<PlayerMovement>().enabled = false;
        pistol.GetComponent<WeaponControl>().enabled = false;

        //Disable Crosshair
        GameObject.FindGameObjectWithTag("Crosshair").GetComponent<Image>().enabled = false;

        //Pause Music
        GameObject.Find("Music").GetComponent<AudioSource>().Pause();
        
        //Enable Mouse Cursor
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        
        //Pause Bool
        gamePaused = true;
    }
    public void Resume()
    {
        //Stop Time
        Time.timeScale = 1;

        //Open Pause Menu
        pauseMenu.SetActive(false);

        //Disable Player Movement and Pistol
        player.GetComponent<PlayerMovement>().enabled = true;
        pistol.GetComponent<WeaponControl>().enabled = true;

        //Disable Crosshair
        GameObject.FindGameObjectWithTag("Crosshair").GetComponent<Image>().enabled = true;

        //Pause Music
        GameObject.Find("Music").GetComponent<AudioSource>().UnPause();

        //Enable Mouse Cursor
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        //Pause Bool
        gamePaused = false;

        //Disable Options Menu
        GameObject.Find("OptionsMenuforPause").SetActive(false);
    }
}

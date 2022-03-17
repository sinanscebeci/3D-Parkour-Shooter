using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private bool playerAlive = true;
    public GameObject deathEffect;
    public AudioClip dead;

    public GameObject hand, crosshair;

    public GameObject gameOverUI;

    public void Death()
    {

        if (playerAlive)
        {
            playerAlive = false;

            //Particle Death Effect
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>().PlayOneShot(dead);

            //Disable Player
            GetComponent<PlayerMovement>().enabled = false;
            hand.SetActive(false);
            crosshair.SetActive(false);

            //Cursor Active
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

            //GameOver UI Active
            gameOverUI.SetActive(true);

            //Disable Music
            //GameObject.Find("Music").GetComponent<AudioSource>().Stop();
        }
    }

    public bool getAliveBool()
    {
        return playerAlive;
    }



}

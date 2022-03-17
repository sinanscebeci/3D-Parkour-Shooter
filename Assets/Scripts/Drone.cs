using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone : MonoBehaviour
{
    public float health = 100f;
    public Vector3 bulletoffset;
    public GameObject drone;
    private float cooldown = 1.3f;
    public Transform player;
    public float dronespeed;
    public float followdistance;
    public Vector3 offset;
    public float rotatespeed;
    public GameObject DroneBullet;
    public GameObject EnemyDeathEffect;
    public AudioClip DeathSound;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void Update()
    {
        FollowPlayer();
        Shot();
        Death();
    }

    private void FollowPlayer()
    {
        //Look at Player
        transform.LookAt(player.position);
        transform.rotation *= Quaternion.Euler(offset);

        //Go to Player

        if (Vector3.Distance(transform.position, player.position) >= followdistance)
        {
            transform.Translate(new Vector3(1, 0, 0) * Time.deltaTime * dronespeed * -1);
        }
        else
        {
            transform.RotateAround(player.position, transform.forward, Time.deltaTime * rotatespeed * Random.Range(0.2f, 3f));
        }

    }
    private void Shot()
    {
        if(cooldown > 0)
        {
            cooldown -= Time.deltaTime;
        }
        else
        {
            cooldown = 1.3f;
            drone.GetComponent<Animator>().SetTrigger("shotTrigger");
            Instantiate(DroneBullet, transform.position, transform.rotation * Quaternion.Euler(new Vector3(0, -90, 0)));
        }


    }
    private void Death()
    {
        if(health <= 0)
        {
            Destroy(this.gameObject);
            Instantiate(EnemyDeathEffect, transform.position, Quaternion.identity);
            GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>().PlayOneShot(DeathSound, 0.4f);
        }

    }

}

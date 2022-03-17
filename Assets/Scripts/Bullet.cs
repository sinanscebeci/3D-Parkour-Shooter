using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 100f;
    public float lifetime = 5f;

    public bool enemybullet = false;
    public LayerMask playerLayer;

    public GameObject hiteffect;
    public AudioClip hitmarker;

    

    private void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);


        lifetime -= Time.deltaTime;

        if(lifetime <= 0)
        {
            Destroy(this.gameObject);
        }

        //Enemy Bullet
        if (enemybullet)
        {
            if(Physics.CheckSphere(transform.position, 0.5f, playerLayer))
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>().Death();
            }
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        //hit enemy
        if (other.CompareTag("enemy"))
        {
            GameObject drone = other.transform.parent.gameObject;
            drone.GetComponent<Drone>().health -= 25f;
            GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>().PlayOneShot(hitmarker,0.4f);

        }

        //hit
        Instantiate(hiteffect, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }


}

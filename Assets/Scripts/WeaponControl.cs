using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponControl : MonoBehaviour
{

    public GameObject hand;
    public LayerMask obstacleLayer;
    public Vector3 offset;

    RaycastHit hit;

    public GameObject bullet;
    public Transform firePoint;
    private float cooldown;
    public AudioClip gunshot;
    private Vector3 startRotation;
    private Vector3 startRotation2;
    private bool ads_on;

    private void Start()
    {
        ads_on = false;
    }

    private void Update()
    {
        //Look

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity, obstacleLayer))
        {
            if (!ads_on)
            {
                hand.transform.LookAt(hit.point);
                hand.transform.rotation *= Quaternion.Euler(offset);
            }
        }
        


        //cooldown

        if (cooldown > 0)
        {
            cooldown -= Time.deltaTime;
        }

        //Shoot
        if (Input.GetMouseButtonDown(0) && cooldown <= 0)
        {
            //Bullet Spawn
            GameObject.Instantiate(bullet, transform.position, transform.rotation * Quaternion.Euler(0, -90, 0));

            //Reset Cooldown
            cooldown = 0.25f;

            //Gun Sound
            GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>().PlayOneShot(gunshot);

            //Animation
            GetComponent<Animator>().SetTrigger("shotTrigger");
            if (ads_on)
            {
                GetComponent<Animator>().SetTrigger("ads_shot");
            }

            
                
            
            
            
        }

        //Aim Down Sight Animation
        if (Input.GetMouseButtonDown(1))
        {
            if (!ads_on)
            {
                GameObject.Find("Hand").GetComponent<Transform>().localEulerAngles = new Vector3(0, 0, 0);
                GameObject.FindGameObjectWithTag("Crosshair").GetComponent<Image>().enabled = false;
                GetComponent<Animator>().SetTrigger("ads_on");
                ads_on = true;
            }
            else
            {
                GameObject.FindGameObjectWithTag("Crosshair").GetComponent<Image>().enabled = true;
                GetComponent<Animator>().SetTrigger("ads_off");
                ads_on = false;
            }
        }


        //Inspect Animation
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (!ads_on)
            {
              GetComponent<Animator>().SetTrigger("inspect");
            }
            if (ads_on)
            {
                GetComponent<Animator>().SetTrigger("ads_inspect");
                GetComponent<Animator>().SetTrigger("ads_inspect_to_idle");
            }
            
            


        }


    }



}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserEnemy : MonoBehaviour
{

    RaycastHit hit;
    public LayerMask obstacle, playerLayer;
    private bool laser_hit;
    public float laseractivedistance;



    private void Update()
    {
        if(Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position) <= laseractivedistance)
        {
            if (Physics.Raycast(transform.position, transform.forward, out hit, 60f, obstacle))
            {
                laser_hit = true;
                GetComponent<LineRenderer>().enabled = true;
                GetComponent<LineRenderer>().SetPosition(0, transform.position);
                GetComponent<LineRenderer>().SetPosition(1, hit.point);

                GetComponent<LineRenderer>().startWidth = 0.075f + Mathf.Sin(Time.time) / 75;

            }
            else
            {
                GetComponent<LineRenderer>().enabled = false;
                laser_hit = false;
            }

            if (Physics.Raycast(transform.position, transform.forward, out hit, 60f, playerLayer) & laser_hit)
            {
                hit.transform.gameObject.GetComponent<PlayerManager>().Death();
            }
        }
        else
        {
            GetComponent<LineRenderer>().enabled = false;
            laser_hit = false;
        }

    }


}

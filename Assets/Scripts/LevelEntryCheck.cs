using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEntryCheck : MonoBehaviour
{
    public LevelManager lm;
    public bool enter;

    private void OnTriggerEnter(Collider other)
    {
        if (enter)
        {
            lm.playerEnter = true;
        }
        else
        {
            lm.playerExit = true;
        }
    }

}

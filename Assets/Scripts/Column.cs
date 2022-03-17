using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Column : MonoBehaviour
{
    public Transform checker;
    public LayerMask playerLayer;
    public float edge;
    private bool broke;
    private Vector3 velocity;

    private void Update()
    {
        if(Physics.CheckBox(checker.position, new Vector3(edge, 1.5f, edge), Quaternion.identity, playerLayer))
        {
            broke = true;
        }

        if (broke)
        {
            velocity.z -= Time.deltaTime / 200;
            transform.Translate(velocity);
        }
    }




}

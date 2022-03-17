using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public Vector3 rotateAxis;
    public float speed;

    private void Update()
    {
        transform.Rotate(rotateAxis * speed * Time.deltaTime);
    }
}

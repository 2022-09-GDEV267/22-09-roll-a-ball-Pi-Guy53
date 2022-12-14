using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingWall : MonoBehaviour
{
    public Transform wall;
    public float speed;
    public float distance;

    public bool goingForward;
    private float t;

    private void Start()
    {
        if(goingForward)
        {
            t = 0;
        }
        else
        {
            t = distance;
        }
    }

    private void Update()
    {
        wall.transform.position = transform.position + transform.forward * t;

        if (goingForward)
        {
            if (t > distance)
            {
                goingForward = false;
            }

            t += Time.deltaTime * speed;
        }
        else
        {
            if (t < 0)
            {
                goingForward = true;
            }

            t += Time.deltaTime * -speed;
        }
    }

}
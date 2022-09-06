using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tiltingPlatform : MonoBehaviour
{
    public int maxRot;
    public float tiltSpeed;

    private float t = 0;
    public int tilt = 0;

    void Update()
    {
        t += tiltSpeed * Time.deltaTime;

        if(t > maxRot * 4)
        {
            tilt = 0;
            t = 0;
        }
        else if(t > maxRot * 3)
        {
            tilt = 3;
        }
        else if(t > maxRot * 2)
        {
            tilt = 2;
        }
        else if(t > maxRot * 1)
        {
            tilt = 1;
        }

        if (tilt == 0)
        {
            transform.Rotate(tiltSpeed * Time.deltaTime, 0, 0);
        }
        else if (tilt == 1)
        {
            transform.Rotate(0, 0, -tiltSpeed * Time.deltaTime);
        }
        else if (tilt == 2)
        {
            transform.Rotate(-tiltSpeed * Time.deltaTime, 0, 0);
        }
        else if (tilt == 3)
        {
            transform.Rotate(0, 0, tiltSpeed * Time.deltaTime);
        }

        transform.rotation = Quaternion.Euler(transform.localEulerAngles.x, 0, transform.localEulerAngles.z);
    }
}
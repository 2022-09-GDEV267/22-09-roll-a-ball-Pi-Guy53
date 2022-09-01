using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    private GameObject player;
    private Vector3 offset;

    void Start()
    {
        player = GameObject.FindObjectOfType<RollerBall>().gameObject;
        offset = transform.position - player.transform.position;
    }

    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
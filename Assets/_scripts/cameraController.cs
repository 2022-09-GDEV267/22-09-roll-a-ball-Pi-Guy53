using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    private GameObject player;
    private Vector3 offset;

    private RaycastHit[] hits;

    private float originalDist;

    void Start()
    {
        player = GameObject.FindObjectOfType<RollerBall>().gameObject;
        offset = transform.position - player.transform.position;

        transform.position = player.transform.position + offset;

        originalDist = Vector3.Distance(transform.position, player.transform.position);
        transform.LookAt(player.transform.position);
    }

    void LateUpdate()
    {
        hits = Physics.RaycastAll(player.transform.position, (player.transform.position + offset) - player.transform.position, originalDist + 2);

        if (hits.Length > 1)
        {
            for (int i = 0; i < hits.Length; i++)
            {
                if (!hits[i].collider.CompareTag("MainCamera"))
                {
                    transform.position = hits[i].point;
                }
            }
        }
        else
        {
            transform.position = player.transform.position + offset;
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    private GameObject player;
    private Vector3 offset;

    private RaycastHit[] hits;

    private float originalDist;

    public LayerMask ignoreLayer;

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
        Vector3 rayPos = player.transform.position + (Vector3.up * 1);

        hits = Physics.RaycastAll(rayPos, (player.transform.position + offset) - rayPos, originalDist + 10, ignoreLayer);

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
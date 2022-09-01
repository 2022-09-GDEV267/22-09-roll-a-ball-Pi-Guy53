using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boostPad : MonoBehaviour
{
    public float boostValue;
    private RollerBall player;

    void Start()
    {
        player = GameObject.FindObjectOfType<RollerBall>();
    }
    private void OnTriggerEnter(Collider other)
    {
        player.rb.AddForce(transform.up * boostValue);
    }
}
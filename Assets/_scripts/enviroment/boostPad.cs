using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boostPad : MonoBehaviour
{
    public float boostValue;
    private RollerBall player;
    public GameObject effects;

    private Vector3 endPoint = Vector3.zero;

    void Start()
    {
        player = GameObject.FindObjectOfType<RollerBall>();
        effects.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        player.rb.velocity = Vector3.zero;
        player.rb.angularVelocity = Vector3.zero;

        player.rb.AddForce(transform.up * boostValue, ForceMode.Impulse);

        effects.SetActive(true);
        Invoke("boostReset", .5f);
    }

    private void boostReset()
    {
        effects.SetActive(false);
    }

    [ContextMenu("calculate")]
    void calculateTrajectory()
    {
        endPoint = transform.position + transform.forward * ((Mathf.Deg2Rad * transform.eulerAngles.x) * ((boostValue * boostValue) / 10));
        endPoint.y = transform.position.y;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(endPoint, .5f);
    }
}
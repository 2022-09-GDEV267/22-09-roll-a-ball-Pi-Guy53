using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUps : MonoBehaviour
{
    public Vector3 rotationValues;
    public int value;
    void Update()
    {
        transform.Rotate(rotationValues * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        ScoreManager.scoreM.collectableTouched(value);

        Destroy(gameObject);
    }
}
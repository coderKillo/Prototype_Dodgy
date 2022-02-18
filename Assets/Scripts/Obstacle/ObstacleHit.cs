using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleHit : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("Hit");
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger");
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Debug.Log("CharColl");
    }
}


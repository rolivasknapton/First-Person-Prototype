using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkIfExplosionHitPlayer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("explosion"))
        {
            Debug.Log("Hit by explosion");
            // You can add more logic here if needed
        }
        else
        {
            Debug.Log("Hit something else");
        }
    }
}

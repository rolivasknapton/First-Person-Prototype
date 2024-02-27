using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class checkIfExplosionHitPlayer : MonoBehaviour
{
    public GameObject deathscreen;
    private Image deathimage;
    private void Start()
    {
        deathscreen = GameObject.Find("DeathScreen");
        deathimage = deathscreen.GetComponent<Image>();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("explosion"))
        {
            Debug.Log("Hit by explosion");
            deathimage.enabled = true;
            // You can add more logic here if needed
        }
        else
        {
            Debug.Log("Hit something else");
        }
    }
}

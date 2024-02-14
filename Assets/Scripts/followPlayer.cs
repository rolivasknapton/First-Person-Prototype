using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayer : MonoBehaviour
{
    public Transform player;
    private void Update()
    {
        float playerX = player.position.x;
        float playerZ = player.position.z;

        // Set the x and z values of this game object's transform
        Vector3 newPosition = new Vector3(playerX, transform.position.y, playerZ);
        transform.position = newPosition;
    }
}

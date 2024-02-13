using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileManagerScript : MonoBehaviour
{
    public static MissileManagerScript instance;
    public GameObject fallingObject;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    public void SpawnMissiles(BoxCollider spawnableAreaCollider)
    {
        Vector3 spawnPosition = GetRandomSpawnPosition(spawnableAreaCollider);
        Debug.Log(spawnPosition);
        GameObject spawnedMissle = Instantiate(fallingObject, spawnPosition, Quaternion.identity);
    }
   public Vector3 GetRandomSpawnPosition(BoxCollider spawnableAreaCollider)
    {
        Vector3 spawnPosition = Vector3.zero;
        spawnPosition = GetRandomPointInCollider(spawnableAreaCollider);
        
        return spawnPosition;
    }
    private Vector3 GetRandomPointInCollider(BoxCollider collider)
    {
        Bounds collBounds = collider.bounds;

        Vector3 minBounds = new Vector3(collBounds.min.x, collBounds.min.y, collBounds.min.z);
        Vector3 maxBounds = new Vector3(collBounds.max.x, collBounds.max.y, collBounds.max.z);

        float randomX = Random.Range(minBounds.x, maxBounds.x);
        float randomZ = Random.Range(minBounds.z, maxBounds.z);

        return new Vector3(randomX, 185, randomZ);



    }
}

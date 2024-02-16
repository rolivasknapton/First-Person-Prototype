using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecreaseSizeOfMissleSpawner : MonoBehaviour
{
    private Collider missleSpawnerArea;
    private void Awake()
    {
        missleSpawnerArea = this.GetComponent<BoxCollider>();
    }
    private void Update()
    {
        //missleSpawnerArea.
    }
}

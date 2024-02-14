using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterActivation : MonoBehaviour
{
    private void OnEnable()
    {
        Invoke("DestroyGameObject", 3f);
    }

    private void DestroyGameObject()
    {
        Destroy(gameObject);
    }
}


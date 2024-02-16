using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateSphereCollider : MonoBehaviour
{
    private Collider sphereCollider;
    private void Start()
    {
        sphereCollider = this.GetComponent<SphereCollider>();
    }

    // Update is called once per frame
    private void OnEnable()
    {
        Invoke("DestroyGameObject", 0.6f);
    }
    private void DestroyGameObject()
    {
        sphereCollider.enabled = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class applyGravity : MonoBehaviour
{
    private CharacterController characterController;
    
    private float gravity = 100;
    void Start()
    {
        characterController = this.GetComponent<CharacterController>();
        
        
    }
    private void Update()
    {
        ApplyGravity();
    }
    void ApplyGravity()
    {
        if (!characterController.isGrounded)
        {
            characterController.Move(Vector3.down * gravity * Time.deltaTime);
        }
    }
}

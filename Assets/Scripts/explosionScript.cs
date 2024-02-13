using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class explosionScript : MonoBehaviour
{ 
    private CharacterController characterController;

    [Header("Camera Shake Parameters")]
    [SerializeField] private CameraShakeController cameraShake;
    [SerializeField] private float shakeIntensity = 5;
    [SerializeField] private float shakeTime = 1;

    void Start()
    {
        characterController = this.GetComponent<CharacterController>();
        cameraShake = GameObject.Find("VirtualCameraOne").GetComponent<CameraShakeController>();


    }
    private void Update()
    {
        checkForGround();
    }
    void checkForGround()
    {
        if (characterController.isGrounded)
        {
            cameraShake.ShakeCamera(shakeIntensity, shakeTime);
            Destroy(this.gameObject);
            
        }
    }
}

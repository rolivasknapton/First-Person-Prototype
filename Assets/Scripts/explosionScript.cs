using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class explosionScript : MonoBehaviour
{
    private CharacterController characterController;

    public GameObject player;
    [Header("Camera Shake Parameters")]
    [SerializeField] private CameraShakeController cameraShake;
    [SerializeField] private float shakeIntensity = 5;
    [SerializeField] private float shakeTime = 1;
    [SerializeField] private float maxShakeIntensity = 20f; // Maximum shake intensity
    [SerializeField] private float minShakeIntensity = 1f; // Minimum shake intensity


    void Start()
    {
        characterController = this.GetComponent<CharacterController>();
        cameraShake = GameObject.Find("VirtualCameraOne").GetComponent<CameraShakeController>();
        player = GameObject.Find("Player");
    }
    private void Update()
    {
        checkForGround();
        AdjustShakeIntensity();
    }
    void checkForGround()
    {
        if (characterController.isGrounded)
        {
            cameraShake.ShakeCamera(shakeIntensity, shakeTime);
            Debug.Log(shakeIntensity);
            Destroy(this.gameObject);

        }
    }
    void AdjustShakeIntensity()
    {
        if (player != null)
        {
            // Calculate the distance between the explosion and the player
            float distance = Vector3.Distance(player.transform.position, transform.position);
            //Debug.Log(distance);

            // Calculate the shake intensity inversely proportional to the distance
            float shakeIntensity = maxShakeIntensity - (distance * 0.25f);

            // Clamp the shake intensity within the desired range
            shakeIntensity = Mathf.Clamp(shakeIntensity, minShakeIntensity, maxShakeIntensity);

           if(shakeIntensity <= 1)
            {
                shakeIntensity = 1;
            }

            // Assign the calculated shake intensity to the class variable

            this.shakeIntensity = shakeIntensity;
        }
    }
}
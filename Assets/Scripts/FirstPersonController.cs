using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class FirstPersonController : MonoBehaviour
{
    public float speed = 5f;
    public float sensitivity = 2f;
    [SerializeField]
    private float gravity = 1;

    private CharacterController characterController;
    public CinemachineVirtualCamera virtualCamera;

    private float verticalRotation = 0f;



    public BoxCollider missilespawnarea;
    

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        missilespawnarea = GameObject.Find("missileSpawner").GetComponent<BoxCollider>();
        Cursor.lockState = CursorLockMode.Locked;
        StartCoroutine(RepeatEvery4Seconds());
    }

    void Update()
    {
        // Rotation
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, -90f, 90f);

        transform.Rotate(Vector3.up * mouseX);
       virtualCamera.transform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);

        // Movement
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");

        Vector3 moveDirection = (transform.forward * verticalMovement + transform.right * horizontalMovement).normalized;
        characterController.Move(moveDirection * speed * Time.deltaTime);

        // Clicking
        if (Input.GetMouseButtonDown(0))
        {
            Click();
        }

        ApplyGravity();
    }

    void Click()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            GameObject hitObject = hit.collider.gameObject;
            //Debug.Log("Clicked on: " + hitObject.name);

            // Perform actions based on the clicked object, for example:
            // hitObject.SendMessage("OnClick", SendMessageOptions.DontRequireReceiver);
        }
        //MissileManagerScript.instance.SpawnMissiles(missilespawnarea);

    }
    void ApplyGravity()
    {
        if (!characterController.isGrounded && characterController.velocity.y > -20f)
        {
            characterController.Move(Vector3.down * gravity * Time.deltaTime);
        }
    }
    void DesiredMethod()
    {
        MissileManagerScript.instance.SpawnMissiles(missilespawnarea);
        //Debug.Log("Executing Desired Method!");
        
        // Place your desired code here
    }

    // Coroutine to call DesiredMethod every 4 seconds
    IEnumerator RepeatEvery4Seconds()
    {
        while (true)
        {
            DesiredMethod();
            yield return new WaitForSeconds(3f);
        }
    }

    // Start the coroutine when the script is enabled
    void OnEnable()
    {
        //StartCoroutine(RepeatEvery4Seconds());
    }

    // Stop the coroutine when the script is disabled or destroyed
    void OnDisable()
    {
        StopCoroutine(RepeatEvery4Seconds());
    }
}   

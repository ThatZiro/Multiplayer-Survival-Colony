using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotatePrev : MonoBehaviour
{
    PlayerControls playerControls;

    Vector2 cameraInput;
    Vector3 currentRotation;
    Vector3 targetRotation;

    public float rotationAmount = 1;
    public float rotationSpeed = 5;


    private void OnEnable() 
    {
        if (playerControls == null)
        {
            playerControls = new PlayerControls();
            playerControls.MovementControls.Camera.performed += i => cameraInput = i.ReadValue<Vector2>(); 
        }

        playerControls.Enable();
    }

    private void Start()  
    {
        currentRotation = transform.eulerAngles;
        targetRotation = transform.eulerAngles;
    }

    private void Update() 
    {
        if (Input.GetMouseButton(1) && cameraInput.x > 0)
        {
            targetRotation.y = targetRotation.y + rotationAmount;
        }
        else if (Input.GetMouseButton(1) && cameraInput.x < 0)
        {
            targetRotation.y = targetRotation.y - rotationAmount;
        }

        currentRotation = Vector3.Lerp(currentRotation, targetRotation, rotationSpeed * Time.deltaTime);
        transform.eulerAngles = currentRotation;
    }
}

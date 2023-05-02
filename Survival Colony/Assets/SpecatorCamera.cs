using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KinematicCharacterController.Examples;
public class SpecatorCamera : MonoBehaviour
{
    public Camera mainCamera;
    public Camera spectatorCamera;
    public ExampleCharacterController controller;
    public KinematicCharacterController.KinematicCharacterMotor motor;

    public float moveSpeed;
    public float lookSensetivity;

    private void Awake()
    {
        mainCamera = Camera.main;
        spectatorCamera.enabled = false;
    }
    public void EnterSpectator()
    {
        mainCamera.enabled = false;
        spectatorCamera.enabled = true;
        transform.position = mainCamera.transform.position;
        transform.rotation = mainCamera.transform.rotation;
        controller.enabled = false;
        motor.enabled = false;
    }

    public void LeaveSpectator()
    {
        mainCamera.enabled = true;
        spectatorCamera.enabled = false;
        controller.enabled = true;
        motor.enabled = true;

    }

    public void Move( Vector2 moveInput)
    {
        Vector3 direction = Vector3.zero;
        direction += spectatorCamera.transform.forward * moveInput.y;
        direction += spectatorCamera.transform.right * moveInput.x;

        transform.position += direction * moveSpeed * Time.deltaTime;

        Vector3 mouseInput = new Vector3(-Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0);
        transform.Rotate(mouseInput * lookSensetivity * Time.deltaTime);
        Vector3 eulerRotation = transform.rotation.eulerAngles;
        transform.rotation = Quaternion.Euler(eulerRotation.x, eulerRotation.y, 0);
    }

   
}

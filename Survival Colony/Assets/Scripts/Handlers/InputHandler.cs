using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private PlayerControls playerControls;
    public AnimationHandler animationHandler;
    public SpecatorCamera spectatorCamera;
    public KinematicCharacterController.Examples.ExampleCharacterController exampleCharacterController;

    public Vector2 MoveInput;

    public bool isSpectator;
    private void OnEnable()
    {
        if (playerControls == null)
        {
            playerControls = new PlayerControls();
            playerControls.MovementControls.Move.performed += move => MoveInput = move.ReadValue<Vector2>();
        }

        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    private void Update()
    {
        TickMenu();
        if (isSpectator)
        {
            TickSpectator();
        }
        else
        {
            TickMovement();
        }
    }

    public void TickMenu()
    {
        if (playerControls.MenuControls.Debug.WasPressedThisFrame())
        {
            //Toggle Debug Menu
            FindAnyObjectByType<ConsoleHandler>().OnToggleDebug();
        }
        if (playerControls.MenuControls.SendCommand.WasPressedThisFrame())
        {
            FindAnyObjectByType<ConsoleHandler>().SendCommand();
        }
    }
    public void TickMovement()
    {

        if (playerControls.MovementControls.Sprint.IsPressed())
        {
            exampleCharacterController.movementMultiplier = exampleCharacterController.sprintMultiplayer;
        }
        else
        {
            exampleCharacterController.movementMultiplier = 1f;
        }
        animationHandler.isSprinting = playerControls.MovementControls.Sprint.IsPressed();
        animationHandler.SetMoveValues(MoveInput);
    }

    public void TickSpectator()
    {
        spectatorCamera.Move(MoveInput);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private PlayerControls playerControls;
    public AnimationHandler animationHandler;
    public KinematicCharacterController.Examples.ExampleCharacterController exampleCharacterController;

    public Vector2 MoveInput;
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
        TickInput();
    }

    public void TickInput()
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
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private PlayerControls playerControls;

    private void OnEnable()
    {
        if (playerControls == null)
        {
            playerControls = new PlayerControls();
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
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    private void Start()
    {
        HideCursor();
    }
    public void ToggleCursor(bool state)
    {
        if(state == true)
        {
            ShowCursor();
        }
        else
        {
            HideCursor();
        }
    } 
    public void ShowCursor()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }

    public void HideCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    
}

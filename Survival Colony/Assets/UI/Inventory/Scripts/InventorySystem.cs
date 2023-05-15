using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class InventorySystem : MonoBehaviour
{
 
   public static InventorySystem Instance { get; set; }
 
    public GameObject inventoryScreenUI;
    public bool isOpen;
 
 
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }
 
 
    void Start()
    {
        isOpen = false;
    }
 
 
    void Update()
    {
 
        if (Input.GetKeyDown(KeyCode.I) && !isOpen)
        {
			ToggleInventoryMenu();
 
        }
        else if (Input.GetKeyDown(KeyCode.I) && isOpen)
        {
            ToggleInventoryMenu();
        }
    }

    public void ToggleInventoryMenu()
    {
        if (!isOpen)
        {
            Debug.Log("i is pressed");
            inventoryScreenUI.SetActive(true);
            isOpen = true;
            FindAnyObjectByType<CursorManager>().ToggleCursor(true);
        }
        else if (isOpen)
        {
            inventoryScreenUI.SetActive(false);
            isOpen = false;
            FindAnyObjectByType<CursorManager>().ToggleCursor(false);                       
        }

    }
 
}
 
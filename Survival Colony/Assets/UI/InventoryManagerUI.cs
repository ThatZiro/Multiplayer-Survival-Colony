using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KinematicCharacterController.Examples;

public class InventoryManagerUI : MonoBehaviour
{
    [Header("Menus")]
    public GameObject inventoryWindow;

    public GameObject equipMenu;
    public GameObject statsMenu;
    public GameObject mapMenu;
    public GameObject socialMenu;    
    public GameObject adminMenu;




    private bool menuIsOpen;

    private void Start()
    {
        inventoryWindow.SetActive(false);
    }

    private void Update()
    {
        //Input Open BuildMenu
        if (Input.GetKeyDown(KeyCode.I))
        {
            ToggleInventoryMenu();
        }


        /*if (Input.GetKeyDown(KeyCode.Escape))
        {

            ToggleBuildMenu();
        }
        */
        menuIsOpen = inventoryWindow.activeInHierarchy;

    }
    public void ToggleInventoryMenu()
    {
        bool open = !inventoryWindow.activeInHierarchy;
        inventoryWindow.SetActive(open);

        FindAnyObjectByType<CursorManager>().ToggleCursor(open);

        if (open)
        {
            //LoadMenu();
        }
        else
        {
            CloseAllMenus();
            //UnloadMenu();
        }
    }

    public void ToggleEquipMenu()
    {
        bool open = !equipMenu.activeInHierarchy;
        CloseSubMenus();
        equipMenu.SetActive(open);
    }

        public void ToggleStatsMenu()
    {
        bool open = !statsMenu.activeInHierarchy;
        CloseSubMenus();
        statsMenu.SetActive(open);
    }
        public void ToggleMapMenu()
    {
        bool open = !mapMenu.activeInHierarchy;
        CloseSubMenus();
        mapMenu.SetActive(open);
        
    }

        public void ToggleSocialMenu()
    {
        bool open = !socialMenu.activeInHierarchy;
        CloseSubMenus();
        socialMenu.SetActive(open);
    }

        public void ToggleAdminMenu()
    {
        bool open = !adminMenu.activeInHierarchy;
        CloseSubMenus();
        adminMenu.SetActive(open);
    }

    private void CloseSubMenus()
    {
        
        equipMenu.SetActive(false);
        statsMenu.SetActive(false);
        mapMenu.SetActive(false);
        socialMenu.SetActive(false);
        adminMenu.SetActive(false);
        FindAnyObjectByType<CursorManager>().ToggleCursor(true);
    }


    private void CloseAllMenus()
    {
        inventoryWindow.SetActive(false);
        equipMenu.SetActive(false);
        statsMenu.SetActive(false);
        mapMenu.SetActive(false);
        socialMenu.SetActive(false);
        adminMenu.SetActive(false);
        FindAnyObjectByType<CursorManager>().ToggleCursor(false);
    }
}

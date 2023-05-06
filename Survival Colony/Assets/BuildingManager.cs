using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    public GameObject[] placedBuildings;

    public GameObject buildMenu;

    public GameObject BuildingsMenu;
    public GameObject CraftingMenu;
    public GameObject FurnitureMenu;
    public GameObject MiscMenu;
    public GameObject AdminMenu;
    public GameObject AdminMenuButton;

    public bool ShowAdminMenu;
    private void Start()
    {
        buildMenu.SetActive(false);
    }
    private void Update()
    {
        if (buildMenu.activeInHierarchy)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            if (ShowAdminMenu)
            {
                AdminMenuButton.SetActive(true);

            }
            else
            {
                AdminMenuButton.SetActive(false);
            }

            ToggleBuildMenu();
        }
    }

    private void ToggleBuildMenu()
    {
        buildMenu.SetActive(!buildMenu.activeInHierarchy);
    }

    public void LoadMenu(int menu)
    {
        CloseAllMenus();
        switch (menu)
        {
            case 1:
                BuildingsMenu.SetActive(true);
                break;
            case 2:
                CraftingMenu.SetActive(true);
                break;
            case 3:
                FurnitureMenu.SetActive(true);
                break;
            case 4:
                MiscMenu.SetActive(true);
                break;
            case 5:
                AdminMenu.SetActive(true);
                break;
        }
    }
    private void CloseAllMenus()
    {
        BuildingsMenu.SetActive(false);
        CraftingMenu.SetActive(false);
        FurnitureMenu.SetActive(false);
        MiscMenu.SetActive(false);
        AdminMenu.SetActive(false);
    }
}

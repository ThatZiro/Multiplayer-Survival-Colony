using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KinematicCharacterController.Examples;

public class BuildingManager : MonoBehaviour
{
    [Header("Menus")]
    public GameObject buildWindow;

    public GameObject buildingsMenu;
    public GameObject craftingMenu;
    public GameObject furnitureMenu;
    public GameObject miscMenu;
    public GameObject adminMenu;

    [Header("Recipes")]
    public BuildingRecipes[] Building_Recipes;
    public BuildingRecipes[] Crafting_Recipes;
    public BuildingRecipes[] Furniture_Recipes;
    public BuildingRecipes[] Misc_Recipes;
    public BuildingRecipes[] Admin_Recipes;

    private BuildingRecipes oldRecipe;
    public BuildingRecipes SelectedRecipe;

    [Header("Ghost")]
    private GameObject selectedObject;
    private Transform cameraTransform;
    public Material placeable;

    [Header("Build Settings")]
    public float placeDistance = 10f;
    private bool menuIsOpen;

    public LayerMask whatIsDestructable;
    public LayerMask whatIsPlaceableTerrain;
    private ExampleCharacterCamera camController;
    private float yOffset = 0;
    private Quaternion rotation = Quaternion.identity;

    private void Start()
    {
        buildWindow.SetActive(false);
        cameraTransform = Camera.main.transform;
        camController = FindObjectOfType<ExampleCharacterCamera>();
    }

    private void Update()
    {
        float Distance = placeDistance + camController.TargetDistance;
        //Input Open BuildMenu
        if (Input.GetKeyDown(KeyCode.B))
        {
            ToggleBuildMenu();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SelectedRecipe = null;
            ToggleBuildMenu();
        }
        menuIsOpen = buildWindow.activeInHierarchy;
        if (SelectedRecipe != oldRecipe)
        {
            oldRecipe = SelectedRecipe;
            Destroy(selectedObject);
            ToggleBuildMenu();
        }
        if (SelectedRecipe != null && selectedObject == null)
        {
            selectedObject = Instantiate(SelectedRecipe.Object);
            selectedObject.transform.rotation = rotation;
            yOffset = 0;
            //Disable All Colliders on Object
            Collider[] col = selectedObject.GetComponentsInChildren<Collider>();
            foreach (Collider c in col)
            {
                c.enabled = false;
            }
        }

        if (selectedObject && menuIsOpen == false)
        {
            RaycastHit hit;
            selectedObject.SetActive(true);

            //ResetRotation
            Vector3 rot = selectedObject.transform.rotation.eulerAngles;
            rot.x = 0;
            selectedObject.transform.rotation = Quaternion.Euler(rot);
            Material[] mats;

            foreach (Renderer rend in selectedObject.GetComponentsInChildren<Renderer>())
            {
                mats = new Material[rend.materials.Length];

                for (int i = 0; i < mats.Length; i++)
                {
                    mats[i] = placeable;
                }

                rend.materials = mats;
            }


            //Handle Rotation ======

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                selectedObject.transform.Rotate(selectedObject.transform.up, 45);
                rotation = selectedObject.transform.rotation;

            }

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                selectedObject.transform.Rotate(selectedObject.transform.up, -45);
                rotation = selectedObject.transform.rotation;
            }

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                yOffset += .25f;
            }

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                yOffset -= .25f;
            }
            //=====

            if (Physics.Raycast(cameraTransform.position, cameraTransform.forward, out hit, Distance, whatIsDestructable))
            {
                if (Input.GetKeyDown(KeyCode.X))
                {
                    Destroy(hit.collider.transform.root.gameObject);
                }
            }

            if (Physics.Raycast(cameraTransform.position, cameraTransform.forward, out hit, Distance, whatIsPlaceableTerrain))
            {
                Vector3 normal = hit.normal;
                //Vector3 offset = SelectedRecipe.MoveCenterIfSnapped;
                Vector3 offset = Vector3.zero;


                //Change Offset based on Controls
                offset += Vector3.up * yOffset;

                //SNAPPOINTS===========================
                if (hit.collider.gameObject.tag == "SnapPoint" && !Input.GetKey(KeyCode.LeftShift))
                {
                    SnapData snapData = hit.collider.GetComponent<SnapData>();


                    if (SelectedRecipe.blockType == BuildingRecipes.BuildingBlockType.Platform)
                    {
                        if (snapData.blockType == BuildingRecipes.BuildingBlockType.Platform)
                        {
                            // Place Agacent to Current Block
                            offset += snapData.transform.forward * (SelectedRecipe.size);
                            selectedObject.transform.position = hit.collider.transform.position + offset;
                        }
                        else if (snapData.blockType == BuildingRecipes.BuildingBlockType.Wall)
                        {
                            //Place Tangent to Wall in Direction of Player
                            offset += normal * (SelectedRecipe.size);
                            selectedObject.transform.position = hit.collider.transform.position + offset;
                        }
                        else
                        {
                            selectedObject.transform.position = hit.collider.transform.position + offset;

                        }
                    }
                    else if (SelectedRecipe.blockType == BuildingRecipes.BuildingBlockType.Wall)
                    {
                        if (snapData.blockType == BuildingRecipes.BuildingBlockType.Platform)
                        {
                            // Place Tangent to Platform based on Normal Direction + or -
                            float u = Vector3.Angle(normal, Vector3.up);
                            float d = Vector3.Angle(normal, Vector3.down);

                            if (u > d)
                            {
                                //Place on  ceiling 
                                offset -= Vector3.up * SelectedRecipe.size;
                            }

                            selectedObject.transform.position = hit.collider.transform.position + offset;
                        }
                        else if (snapData.blockType == BuildingRecipes.BuildingBlockType.Wall)
                        {
                            if(snapData.transform.forward == Vector3.up)
                            {
                                //Do Nothing
                            } else if(snapData.transform.forward == Vector3.down)
                            {
                                //Move Down 2 Units
                                offset += snapData.transform.forward * SelectedRecipe.size;
                            }
                            else
                            {
                                offset += snapData.transform.forward * SelectedRecipe.size/2;
                                offset += Vector3.down * SelectedRecipe.size / 2;

                            }

                            selectedObject.transform.position = hit.collider.transform.position + offset;

                        }
                        else
                        {

                            selectedObject.transform.position = hit.collider.transform.position + offset;
                        }
                    }
                    else if (SelectedRecipe.blockType == BuildingRecipes.BuildingBlockType.Other)
                    {
                        
                        selectedObject.transform.position = hit.collider.transform.position + offset;

                        //Bug ===== When trying to place an object snappoint at the bottom, the object is constantly rotating
                        /*
                        Vector3 offsetRotation = rot;
                        if (normal == Vector3.down)
                        {
                            offsetRotation.x = 180;
                        }

                        selectedObject.transform.rotation = Quaternion.Euler(offsetRotation);*/
                    }
                    else
                    {
                        Debug.Log("Unknown BlockType is being placed " + SelectedRecipe);
                    }

                }
                else //=================================================================
                {
                    selectedObject.transform.position = hit.point + Vector3.up * yOffset;
                }

            }
            else
            {
                selectedObject.SetActive(false);
            }
            if (Input.GetMouseButtonDown(0))
            {
                Instantiate(SelectedRecipe.Object, selectedObject.transform.position, selectedObject.transform.rotation);
                Destroy(selectedObject);
                selectedObject = null;
            }

        }
        else
        {
            if (selectedObject != null)
            {
                selectedObject.SetActive(false);
            }
        }
    }
    public void ToggleBuildMenu()
    {
        bool open = !buildWindow.activeInHierarchy;
        buildWindow.SetActive(open);

        FindAnyObjectByType<CursorManager>().ToggleCursor(open);

        yOffset = 0;

        if (open)
        {
            //LoadMenu();
        }
        else
        {
            //UnloadMenu();
        }
    }

    public void LoadBuildMenu(int menu)
    {
        CloseAllMenus();
        switch (menu)
        {
            case 0: // Buildings
                buildingsMenu.SetActive(true);
                buildingsMenu.GetComponent<LoadBuildingMenu>().LoadMenu(Building_Recipes);
                break;
            case 1: // Crafting
                craftingMenu.SetActive(true);
                craftingMenu.GetComponent<LoadBuildingMenu>().LoadMenu(Crafting_Recipes);
                break;
            case 2: // Furniture
                furnitureMenu.SetActive(true);
                furnitureMenu.GetComponent<LoadBuildingMenu>().LoadMenu(Furniture_Recipes);
                break;
            case 3: // Misc
                miscMenu.SetActive(true);
                miscMenu.GetComponent<LoadBuildingMenu>().LoadMenu(Misc_Recipes);
                break;
            case 4: // Admin
                adminMenu.SetActive(true);
                adminMenu.GetComponent<LoadBuildingMenu>().LoadMenu(Admin_Recipes);
                break;
        }
    }

    private void CloseAllMenus()
    {
        buildingsMenu.SetActive(false);
        furnitureMenu.SetActive(false);
        craftingMenu.SetActive(false);
        miscMenu.SetActive(false);
        adminMenu.SetActive(false);
    }



}

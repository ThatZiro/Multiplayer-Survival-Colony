using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadBuildingMenu : MonoBehaviour
{
    public GameObject ButtonPrefab;
    private List<GameObject> Buttons = new List<GameObject>();
    private static int maxButtons = 60;
    public void LoadMenu(BuildingRecipes[] recipes)
    {
        UnloadMenu();

        for (int i = 0; i < maxButtons; i++)
        {
            GameObject GO = Instantiate(ButtonPrefab, transform);
            Buttons.Add(GO);

            if (i < recipes.Length)
            {
                Buttons[i].GetComponent<LoadBuildingButton>().LoadRecipe(recipes[i]);
            }
            else
            {
                Buttons[i].GetComponent<LoadBuildingButton>().icon.enabled = false;
            }
        }

        for (int i = 0; i < recipes.Length; i++)
        {
            if(i <= Buttons.Count)
            {
                Buttons[i].GetComponent<LoadBuildingButton>().LoadRecipe(recipes[i]);
            }
            else
            {
                Debug.Log("Unable to load recipe : No button avalible");
            }
        }
    }

    public void UnloadMenu()
    {
        foreach(GameObject button in Buttons)
        {
            Destroy(button);
        }
        Buttons.Clear();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LoadBuildingButton : MonoBehaviour
{
    public BuildingRecipes loadedRecipe;
    public Image icon;

    public void LoadRecipe(BuildingRecipes recipe)
    {
        loadedRecipe = recipe;
        icon.enabled = true;
        icon.sprite = recipe.icon;
    }

    public void SelectRecipe()
    {
        if(loadedRecipe != null)
        {
            BuildingManager BM = FindAnyObjectByType<BuildingManager>();
            BM.SelectedRecipe = loadedRecipe;
        }
    }
}

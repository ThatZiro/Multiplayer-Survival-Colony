using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Building Recipe")]
public class BuildingRecipes : ScriptableObject
{
    public bool isBuildable;
    public GameObject Object;

    public Sprite icon;
    public string recipeName;
    //public ItemStack[] cost;
    public int size;

    public enum BuildingBlockType { Platform, Wall, Other }
    public BuildingBlockType blockType;
}

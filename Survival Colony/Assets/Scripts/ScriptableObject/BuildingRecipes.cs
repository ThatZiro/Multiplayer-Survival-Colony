using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Building Recipe")]
public class BuildingRecipes : ScriptableObject
{

    public GameObject buildingObject;
    public enum placementMode { Wall, Platform, Default};
    public placementMode placeMode;

    public int size;
}

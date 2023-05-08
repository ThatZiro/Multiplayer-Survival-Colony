using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapData : MonoBehaviour
{
    public bool snapToCenter;
    public BuildingRecipes.BuildingBlockType blockType;
    private void Start()
    {
        gameObject.tag = "SnapPoint";
    }

}

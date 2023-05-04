using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [Header("Islands")]

    public GameObject starterIsland_0;
    public GameObject starterIsland_1;
    public GameObject starterIsland_2;
    public GameObject starterIsland_3;

    public GameObject[] smallIslands;

    public GameObject[] mediumIslands;

    public GameObject[] largeIslands;


    [Header("World Settings")]
    [Range(0,3)]
    public int starterIsland;

    public int seed;

    [Range(1, 100)]
    public int worldSize;
    public int worldSpread;


    private void Start()
    {
        worldSize = worldSize * worldSpread;

        switch (starterIsland)
        {
            case 0:
                SpawnIsland(starterIsland_0, Vector2.zero);
                break;

        }
    }

    public void SpawnIsland(GameObject island, Vector2 location)
    {
        Vector3 pos = new Vector3(location.x * worldSpread, 0, location.y * worldSpread);
        Instantiate(island, pos, Quaternion.identity);
    }

}

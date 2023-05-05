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


    [Header("Sea")]
    public GameObject waterPlane;
    public float sealevel;

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
            case 1:
                SpawnIsland(starterIsland_1, Vector2.zero);
                break;
            case 2:
                SpawnIsland(starterIsland_2, Vector2.zero);
                break;
            case 3:
                SpawnIsland(starterIsland_3, Vector2.zero);
                break;

        }
    }

    public void SpawnIsland(GameObject island, Vector2 location)
    {

        Instantiate(waterPlane, Vector3.up * sealevel, Quaternion.identity);

        int randomDirection = Random.Range(0, 4);

        Vector2 offset = new Vector2(worldSize, worldSize);
        switch (randomDirection)
        {
            case 0:
                offset *= new Vector2(-1, 0);
                break;
            case 1:
                offset *= new Vector2(0, 0);
                break;
            case 2:
                offset *= new Vector2(-1, -1);
                break;
            case 3:
                offset *= new Vector2(0, -1);
                break;
        }
        location -= offset;
        Vector3 pos = new Vector3(location.x * worldSpread, 0, location.y * worldSpread);
        Instantiate(island, pos, Quaternion.identity);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject Player;

    public float spawnRange = 250;

    private void Start()
    {
        Invoke("SpawnPlayer", .01f);
    }

    public void SpawnPlayer()
    {
        float x = Random.Range(0, spawnRange);
        float z = Random.Range(0, spawnRange);

        transform.position = new Vector3(x, transform.position.y, z);
        RaycastHit hit;

        if(Physics.Raycast(transform.position, Vector3.down, out hit, 500f))
        {
            if (hit.collider.tag == "Terrain")
            {
                Player.GetComponent<KinematicCharacterController.KinematicCharacterMotor>().SetPosition(hit.point);
            }
            else
            {
                SpawnPlayer();
            }
        }
        else
        {
            print("Unable to find location");
            SpawnPlayer();
        }
    }
}

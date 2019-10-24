using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetSpawnerScript : MonoBehaviour
{
    //planet prefabs
    public Transform planetPrefab1;
    public Transform planetPrefab2;
    public Transform planetPrefab3;
    public Transform planetPrefab4;
    public Transform planetPrefab5;
    public Transform planetPrefab6;
    public Transform planetPrefab7;
    public Transform planetPrefab8;

    //layer to spawn into
    public Transform layer;

    //spawn rate
    public float spawnRate = 1.00f;
    private float spawnCooldown;

    private float xmin = 7.0f;
    private float xmax = 8.0f;
    private float ymin = -2.4f;
    private float ymax = +2.4f;

    void Start()
    {
        spawnCooldown = 0f;
    }

    void Update()
    {
        if (spawnCooldown > 0)
        {
            spawnCooldown -= Time.deltaTime;
        }
        else
        {
            SpawnPlanet();
            spawnCooldown = spawnRate;
        }
    }

    public void SpawnPlanet()
    {
        //get random pposition
        Vector3 position = new Vector3(Random.Range(xmin, xmax), Random.Range(ymin, ymax), 0);

        //get random prefab
        int index = Random.Range(1, 8);

        switch (index)
        {
            case 1:
                Instantiate(planetPrefab1, position, transform.rotation, layer);
                break;
            case 2:
                Instantiate(planetPrefab2, position, transform.rotation, layer);
                break;
            case 3:
                Instantiate(planetPrefab3, position, transform.rotation, layer);
                break;
            case 4:
                Instantiate(planetPrefab4, position, transform.rotation, layer);
                break;
            case 5:
                Instantiate(planetPrefab5, position, transform.rotation, layer);
                break;
            case 6:
                Instantiate(planetPrefab6, position, transform.rotation, layer);
                break;
            case 7:
                Instantiate(planetPrefab7, position, transform.rotation, layer);
                break;
            case 8:
                Instantiate(planetPrefab8, position, transform.rotation, layer);
                break;
            default:
                print("planetSpawn -> this default case should not happen");
                break;  
        }
    }
}

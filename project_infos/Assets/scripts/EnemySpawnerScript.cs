using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour
{
    //enemy prefabs
    public Transform enemyPrefab1;
    public Transform enemyPrefab2;
    public Transform enemyPrefab3;

    //layer to spawn into
    public Transform layer;

    //spawn rate
    public float spawnRate = 1.00f;
    private float spawnCooldown;

    private float xmin = 7.0f;
    private float xmax = 8.0f;
    private float ymin = -2.3f;
    private float ymax = +2.3f;

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
            SpawnEnemy();
            spawnCooldown = spawnRate;
        }
    }

    public void SpawnEnemy()
    {
        //get random pposition
        Vector3 position = new Vector3(Random.Range(xmin, xmax), Random.Range(ymin, ymax), 0);

        //get random prefab
        int index = (int)Random.Range(1.0f, 3.99f);

        switch (index)
        {
            case 1:
                Instantiate(enemyPrefab1, position, transform.rotation, layer);
                break;
            case 2:
                Instantiate(enemyPrefab2, position, transform.rotation, layer);
                break;
            case 3:
                Instantiate(enemyPrefab3, position, transform.rotation, layer);
                break;
            default:
                print("enemySpawn -> this default case should not happen");
                break;
        }
    }
}

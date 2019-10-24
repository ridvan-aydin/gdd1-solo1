using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnerScript : MonoBehaviour
{
    //player prefabs
    public Transform spaceshipPrefab1;
    public Transform spaceshipPrefab2;

    void Start()
    {
        var persistentData = FindObjectOfType<PersistentDataScript>();
        if(persistentData != null)
        {
            if(persistentData.spaceship == 1)
            {
                var playerTransform = Instantiate(spaceshipPrefab1) as Transform;
                playerTransform.position = transform.position;
            }
            if(persistentData.spaceship == 2)
            {
                var playerTransform = Instantiate(spaceshipPrefab2) as Transform;
                playerTransform.position = transform.position;
            }
        }
        else
        {
            var playerTransform = Instantiate(spaceshipPrefab1) as Transform;
            playerTransform.position = transform.position;
        }
    }
}

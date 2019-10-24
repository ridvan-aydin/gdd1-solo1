using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//enemy generic behaviour
public class EnemyScript : MonoBehaviour
{
    private bool hasSpawn;
    private MoveScript moveScript;
    private WeaponScript[] weapons;
    private Collider2D coliderComponent;
    private SpriteRenderer rendererComponent;

    private void Awake()
    {
        //retrieve the weapon only once
        weapons = GetComponentsInChildren<WeaponScript>();

        // Retrieve scripts to disable when not spawn
        moveScript = GetComponent<MoveScript>();
        coliderComponent = GetComponent<Collider2D>();
        rendererComponent = GetComponent<SpriteRenderer>();
    }

    // 1 - Disable everything
    void Start()
    {
        hasSpawn = false;

        // Disable everything, collider, moving, shooting
        coliderComponent.enabled = false;
        //moveScript.enabled = false;
        foreach (WeaponScript weapon in weapons)
        {
            weapon.enabled = false;
        }
    }

    void Update()
    {
        // 2 - Check if the enemy has spawned.
        if (hasSpawn == false)
        {
            if (rendererComponent.IsVisibleFrom(Camera.main))
            {
                Spawn();
            }
        }
        else
        {
            foreach (WeaponScript weapon in weapons)
            {
                //auto-fire
                if (weapon != null && weapon.CanAttack)
                {
                    weapon.Attack(true, false);
                }
            }

            // 4 - Out of the camera ? Destroy the game object.
            if (rendererComponent.IsVisibleFrom(Camera.main) == false)
            {
                Destroy(gameObject);
            }
        }
    }

    // 3 - Activate itself.
    private void Spawn()
    {
        hasSpawn = true;

        // Enable everything, collider, moving, shooting
        coliderComponent.enabled = true;
        moveScript.enabled = true;
        foreach (WeaponScript weapon in weapons)
        {
            weapon.enabled = true;
        }
    }
}

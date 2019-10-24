using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//launch projectile
public class WeaponScript : MonoBehaviour
{
    //--------------------------------
    // 1 - Designer variables
    //--------------------------------

    // Projectile prefab for shooting
    public Transform shotPrefab1;
    public Transform shotPrefab2;

    // Cooldown in seconds between two shots
    public float normalShootingRate = 0.25f;
    public float nukeShootingRate = 1.00f;

    //--------------------------------
    // 2 - Cooldown
    //--------------------------------

    private float shootCooldown;

    void Start()
    {
        shootCooldown = 0f;
    }

    void Update()
    {
        if (shootCooldown > 0)
        {
            shootCooldown -= Time.deltaTime;
        }
    }

    //--------------------------------
    // 3 - Shooting from another script
    //--------------------------------

    // Create a new projectile if possible
    public void Attack(bool isEnemy, bool isNuke)
    {
        if (CanAttack)
        {
            if (isNuke)
            {
                shootCooldown = nukeShootingRate;
                var shotTransform = Instantiate(shotPrefab2) as Transform;
                
                // Assign position
                shotTransform.position = transform.position;

                // The is enemy property
                ShotScript shot = shotTransform.gameObject.GetComponent<ShotScript>();
                if (shot != null)
                {
                    shot.isEnemyShot = isEnemy;
                }

                // Make the weapon shot always towards it
                MoveScript move = shotTransform.gameObject.GetComponent<MoveScript>();
                if (move != null)
                {
                    move.direction = this.transform.right; // towards in 2D space is the right of the sprite
                }
            }
            else
            {
                shootCooldown = normalShootingRate;

                // Create a new shot
                var shotTransform = Instantiate(shotPrefab1) as Transform;

                // Assign position
                shotTransform.position = transform.position;

                // The is enemy property
                ShotScript shot = shotTransform.gameObject.GetComponent<ShotScript>();
                if (shot != null)
                {
                    shot.isEnemyShot = isEnemy;
                }

                // Make the weapon shot always towards it
                MoveScript move = shotTransform.gameObject.GetComponent<MoveScript>();
                if (move != null)
                {
                    move.direction = this.transform.right; // towards in 2D space is the right of the sprite
                }
            }
        }
    }

    // Is the weapon ready to create a new projectile?
    public bool CanAttack
    {
        get
        {
            return shootCooldown <= 0f;
        }
    }
}

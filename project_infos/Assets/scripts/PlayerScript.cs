using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//player controller and behaviour
public class PlayerScript : MonoBehaviour
{
    //speed of the player
    public Vector2 speed = new Vector2(50, 50);

    //store the movement and component
    private Vector2 movement;
    private Rigidbody2D rigidbodyComponent;

    private void Update()
    {
        //retrieve axis information
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        movement = new Vector2(speed.x * inputX, speed.y * inputY);

        //shooting
        bool normal = Input.GetButtonDown("Fire1");
        bool nuke = Input.GetButtonDown("Fire2");

        if (normal)
        {
            WeaponScript weapon = GetComponent<WeaponScript>();
            if (weapon != null)
            {
                //false because the player is not an enemy
                weapon.Attack(false, false);
            }
        }

        if (nuke)
        {
            WeaponScript weapon = GetComponent<WeaponScript>();
            if (weapon != null)
            {
                //false because the player is not an enemy
                weapon.Attack(false, true);
            }
        }

        //make sure we are not outside the camera bounds
        var dist = (transform.position - Camera.main.transform.position).z;

        var leftBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, dist)).x;
        var rightBorder = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, dist)).x;
        var topBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, dist)).y;
        var bottomBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, dist)).y;

        transform.position = new Vector3(
          Mathf.Clamp(transform.position.x, leftBorder, rightBorder),
          Mathf.Clamp(transform.position.y, topBorder, bottomBorder),
          transform.position.z
        );
    }

    private void FixedUpdate()
    {
        //get the component and store the reference
        if(rigidbodyComponent == null)
        {
            rigidbodyComponent = GetComponent<Rigidbody2D>();
        }

        //move the game object
        rigidbodyComponent.velocity = movement;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        bool damagePlayer = false;

        //collision with enemy
        EnemyScript enemy = collision.gameObject.GetComponent<EnemyScript>();
        if (enemy != null)
        {
            //kill the enemy
            HealthScript enemyHealth = enemy.GetComponent<HealthScript>();
            if (enemyHealth != null) enemyHealth.Damage(enemyHealth.hp);

            damagePlayer = true;
        }

        //damage the player
        if (damagePlayer)
        {
            HealthScript playerHealth = this.GetComponent<HealthScript>();
            if (playerHealth != null)
            {
                playerHealth.Damage(1);
            } 
        }
    }

    void OnDestroy()
    {
        // Game Over.
        var gameOver = FindObjectOfType<GameOverScript>();
        gameOver.ShowButtons();
    }

}

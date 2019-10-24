using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//simply moves the current game object
public class MoveScript : MonoBehaviour
{
    ////designer variables

    //object speed
    public Vector2 speed = new Vector2(10, 10);

    //moving direction
    public Vector2 direction = new Vector2(-1, 0);

    private Vector2 movement;
    private Rigidbody2D rigidbodyComponent;


    private void Update()
    {
        //movement
        movement = new Vector2(speed.x * direction.x, speed.y * direction.y);
    }

    private void FixedUpdate()
    {
        if(rigidbodyComponent == null)
        {
            rigidbodyComponent = GetComponent<Rigidbody2D>();
        }

        //apply movement to the rigidbody
        rigidbodyComponent.velocity = movement;
    }
}

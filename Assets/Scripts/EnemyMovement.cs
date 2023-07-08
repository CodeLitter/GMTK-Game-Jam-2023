using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyMovement : MonoBehaviour 
{
    public bool movingLeft;
    public Rigidbody2D rigidbody2D;
    public Transform patrolPointLeft;
    public Transform patrolPointRight;

    public Vector2 speed = Vector2.one;
    private Vector2 velocity;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per framed
    private void FixedUpdate()
    {
        velocity.x = 30.0f * (movingLeft ? -1.0f : 1.0f);
        var currentVelocity = rigidbody2D.velocity;
        currentVelocity.x = velocity.x * (speed.x * Time.fixedDeltaTime);
        rigidbody2D.velocity = currentVelocity / rigidbody2D.mass;
        
        if (movingLeft && (rigidbody2D.transform.position.x <= patrolPointLeft.position.x))
        {
            movingLeft = false;
        }
        else if (!movingLeft && (rigidbody2D.transform.position.x >= patrolPointRight.position.x))
        {
            movingLeft = true;
        }

    }
}

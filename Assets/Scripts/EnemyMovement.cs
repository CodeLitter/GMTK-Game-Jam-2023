using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyMovement : MonoBehaviour
{
   public bool patroling;
   public bool movingLeft;
   public bool movingDown;
   public bool chaseTargetX;
   public bool chaseTargetY;
   public Rigidbody2D rigidbody2D;
   public Transform patrolPointLeft;
   public Transform patrolPointRight;
   public Vector2 speed = Vector2.one;

   private bool pursuingTarget = false;
   private Transform target;
   private Vector2 velocity;

   private void Awake()
   {
      rigidbody2D = GetComponent<Rigidbody2D>();
   }

   // Update is called once per framed
   private void FixedUpdate()
   {
      if (!pursuingTarget)
      {
         if (movingLeft)
            target = patrolPointLeft;
         else
            target = patrolPointRight;
      }
      moveTowardsTarget(target);
   }

   private void OnTriggerEnter2D(Collider2D collision)
   {
      if (collision.CompareTag("Player"))
      {
         target = collision.gameObject.transform;
         pursuingTarget = true;
      }
   }

   private void OnTriggerExit2D(Collider2D collision)
   {
      if (collision.CompareTag("Player") && patrolPointRight != null)
      {
         target = (Vector3.Distance(transform.position, patrolPointLeft.position) >= Vector3.Distance(transform.position, patrolPointRight.position) ? patrolPointLeft : patrolPointRight);
         pursuingTarget = false;
      }
      else if (collision.CompareTag("Player"))
      {
         target = null;
         pursuingTarget = false;
      }
   }

   private void moveTowardsTarget(Transform target)
   {
      var currentVelocity = rigidbody2D.velocity;

      if (chaseTargetX)
      {
         velocity.x = 30.0f * (movingLeft ? -1.0f : 1.0f);
         currentVelocity.x = velocity.x * (speed.x * Time.fixedDeltaTime);
      }

      if (chaseTargetY)
      {
         velocity.y = 30.0f * (movingDown ? -1.0f : 1.0f);
         currentVelocity.y = velocity.y * (speed.y * Time.fixedDeltaTime);
      }

      rigidbody2D.velocity = currentVelocity / rigidbody2D.mass;

      if (chaseTargetX)
      {
         if (movingLeft && (rigidbody2D.transform.position.x <= target.position.x))
         {
            movingLeft = false;
         }
         else if (!movingLeft && (rigidbody2D.transform.position.x >= target.position.x))
         {
            movingLeft = true;
         }
      }

      if (chaseTargetY)
      {
         if (movingDown && (rigidbody2D.transform.position.y <= target.position.y))
         {
            movingDown = false;
         }
         else if (!movingDown && (rigidbody2D.transform.position.y >= target.position.y))
         {
            movingDown = true;
         }
      }
   }
}

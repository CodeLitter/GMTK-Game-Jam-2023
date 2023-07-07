using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
	public Rigidbody2D rigidbody2D;
	public Vector2 speed = Vector2.one;
	private Vector2 velocity;
	
	private void Awake()
	{
		rigidbody2D = GetComponent<Rigidbody2D>();
	}

	private void FixedUpdate()
	{
		if (rigidbody2D.velocity.y > 0)
		{
			rigidbody2D.gravityScale = 1;
		}
		else
		{
			rigidbody2D.gravityScale = 2;
		}
		
		var currentVelocity = rigidbody2D.velocity;
		currentVelocity.x = velocity.x * (speed.x * Time.fixedDeltaTime);
		rigidbody2D.velocity = currentVelocity;
	}

	public void OnMove(InputValue value)
	{
		var input = value.Get<Vector2>();
		velocity.x = input.x;
	}

	public void OnJump(InputValue value)
	{
		rigidbody2D.velocity = new Vector2(
			rigidbody2D.velocity.x,
			0
		);
		rigidbody2D.AddForce(Vector2.up * speed.y, ForceMode2D.Impulse);
	}
}

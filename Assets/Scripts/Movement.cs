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
	public LayerMask floorLayers;
	private Vector2 _velocity;
	public bool _isGrounded;

	private void Awake()
	{
		rigidbody2D = GetComponent<Rigidbody2D>();
	}

	private void Update()
	{
		var hit = Physics2D.Raycast(transform.position, Vector2.down, 1, floorLayers);
		_isGrounded = (hit.collider != null);
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
		if (_isGrounded || (int) Mathf.Sign(rigidbody2D.velocity.x) == (int) Mathf.Sign(_velocity.x))
		{
			currentVelocity.x = _velocity.x * (speed.x * Time.fixedDeltaTime);
			rigidbody2D.velocity = currentVelocity;
		}
		else
		{
			rigidbody2D.AddForce(Vector2.right * (_velocity.x * (speed.x * Time.fixedDeltaTime)));
		}
	}

	public void OnMove(InputValue value)
	{
		var input = value.Get<Vector2>();
		_velocity.x = input.x;
	}

	public void OnJump(InputValue value)
	{
		if (!enabled)
			return;
		if (_isGrounded)
		{
			rigidbody2D.velocity = new Vector2(
				rigidbody2D.velocity.x,
				0
			);
			rigidbody2D.AddForce(Vector2.up * speed.y, ForceMode2D.Impulse);
		}
	}
}
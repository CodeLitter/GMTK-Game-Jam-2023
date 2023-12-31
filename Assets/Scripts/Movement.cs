using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
	public Rigidbody2D rigidbody2D;
	public Collider2D collider2D;
	public Vector2 speed = Vector2.one;
	public int jumpCount = 1;
	public LayerMask floorLayers;
	private Vector2 _velocity;
	public bool _isGrounded;
	public int _currentJump;

	private void Awake()
	{
		rigidbody2D = GetComponent<Rigidbody2D>();
		collider2D = GetComponent<Collider2D>();
	}

	private void Update()
	{
		var hit = Physics2D.Raycast(
			transform.position + Vector3.down * collider2D.bounds.extents.y, 
			Vector2.down, 0.25f,
			floorLayers);
		_isGrounded = (hit.collider != null);
		if (_isGrounded)
		{
			_currentJump = 1;
		}
	}

	private void FixedUpdate()
	{
		if (rigidbody2D.velocity.y > 0)
		{
			rigidbody2D.gravityScale = 1 / rigidbody2D.mass;
		}
		else
		{
			rigidbody2D.gravityScale = 2 / rigidbody2D.mass;
		}

		var currentVelocity = rigidbody2D.velocity;
		if (_isGrounded || (int) Mathf.Sign(rigidbody2D.velocity.x) == (int) Mathf.Sign(_velocity.x))
		{
			currentVelocity.x = _velocity.x * (speed.x * Time.fixedDeltaTime) / rigidbody2D.mass;
			rigidbody2D.velocity = currentVelocity;
		}
		else
		{
			rigidbody2D.AddForce(Vector2.right * (_velocity.x * speed.x * Time.fixedDeltaTime));
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
		if (_isGrounded || _currentJump < jumpCount)
		{
			rigidbody2D.velocity = new Vector2(
				rigidbody2D.velocity.x,
				0
			);
			rigidbody2D.AddForce(Vector2.up * speed.y, ForceMode2D.Impulse);
			_currentJump++;
		}
	}
}
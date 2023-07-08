using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class SpriteFlipper : MonoBehaviour
{
	[FormerlySerializedAs("Rigidbody2D")] public Rigidbody2D rigidbody2D;
	[FormerlySerializedAs("SpriteRenderer")] public SpriteRenderer spriteRenderer;

	private void Awake()
	{
		rigidbody2D = GetComponent<Rigidbody2D>();
		spriteRenderer = GetComponent<SpriteRenderer>();
	}

	private void Update()
	{
		if (rigidbody2D.velocity.x < 0)
		{
			spriteRenderer.flipX = true;
		}
		else if (rigidbody2D.velocity.x > 0)
		{
			spriteRenderer.flipX = false;
		}
	}
}

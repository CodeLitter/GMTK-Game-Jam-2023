using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceTarget : MonoBehaviour
{
	public Transform target;
	public SpriteRenderer spriteRenderer;

	private void Update()
	{
		if (target.position.x < transform.position.x)
		{
			transform.rotation = Quaternion.Euler(0, 180, 0);
			spriteRenderer.flipX = true;
		}
		else
		{
			transform.rotation = Quaternion.Euler(0, 0, 0);
			spriteRenderer.flipX = false;
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceDirection : MonoBehaviour
{
	public SpriteRenderer spriteRenderer;

	private void Update()
	{
		transform.rotation = Quaternion.Euler(0, spriteRenderer.flipX ? 180 : 0, 0);
	}
}
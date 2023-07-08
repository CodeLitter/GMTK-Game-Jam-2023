using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceTarget : MonoBehaviour
{
	public Transform target;

	private void Update()
	{
		var scale = transform.localScale;
		if (target.position.x < transform.position.x)
		{
			scale.x = -1;
		}
		else
		{
			scale.x = 1;
		}
		transform.localScale = scale;
	}
}

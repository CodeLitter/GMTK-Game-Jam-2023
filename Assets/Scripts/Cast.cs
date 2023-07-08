using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class Cast : MonoBehaviour
{
	public UnityEvent<Transform> onCast;
	public UnityEvent<Vector2> onCastAtPoint;

	public void OnFire(InputValue value)
	{
		var mousePos = Mouse.current.position.value;
		var worldPoint = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 0));
		var hit = Physics2D.Raycast(worldPoint, UnityEngine.Vector2.zero);
		if (hit.collider != null)
		{
			onCast.Invoke(hit.transform);
		}
		onCastAtPoint.Invoke(worldPoint);
	}
}

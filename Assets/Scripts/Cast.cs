using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Vector2 = System.Numerics.Vector2;

public class Cast : MonoBehaviour
{
	public Camera camera;
	
	public void OnFire(InputValue value)
	{
		var mousePos = Mouse.current.position.value;
		var worldPoint = camera.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 0));
		var hit = Physics2D.Raycast(worldPoint, UnityEngine.Vector2.zero);
		if (hit.collider != null)
		{
			foreach (Transform child in transform)
			{
				if (child.gameObject.activeSelf)
				{
					child.SendMessage("OnCast", hit.transform, SendMessageOptions.RequireReceiver);
				}
			}
		}
	}
}

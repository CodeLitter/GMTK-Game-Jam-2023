using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class Cast : MonoBehaviour
{
	public float cooldown = 1;
	public UnityEvent<Transform> onCast;
	public UnityEvent<Vector2> onCastAtPoint;

	public float CooldownTimeElapsed { get; private set; }

	private void Awake()
	{
		CooldownTimeElapsed = cooldown;
	}

	private void Update()
	{
		CooldownTimeElapsed = CooldownTimeElapsed + Time.deltaTime;
	}

	public void OnFire(InputValue value)
	{
		if (CooldownTimeElapsed < cooldown)
			return;
		var mousePos = Mouse.current.position.value;
		var worldPoint = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 0));
		var hit = Physics2D.Raycast(worldPoint, Vector2.zero);
		if (hit.collider != null)
		{
			onCast.Invoke(hit.transform);
		}

		onCastAtPoint.Invoke(worldPoint);
		CooldownTimeElapsed = 0;
	}
}
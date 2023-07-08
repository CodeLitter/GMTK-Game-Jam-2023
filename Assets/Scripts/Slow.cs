using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slow : MonoBehaviour
{
	public float radius = 1;
	public float factor = 1;
	public float duration = 1;

	public void OnCast(Vector2 position)
	{
		if (!enabled || !gameObject.activeSelf)
			return;
		var hits = Physics2D.OverlapCircleAll(position, radius);
		if (hits != null)
		{
			foreach (var hit in hits)
			{
				StartCoroutine(ApplySlow(hit.transform));
			}
		}
	}

	private IEnumerator ApplySlow(Transform target)
	{
		var rb2d = target.GetComponent<Rigidbody2D>();
		if (rb2d != null)
		{
			var prevMass = rb2d.mass;
			rb2d.mass = factor;
			rb2d.velocity *=  prevMass / factor;
			rb2d.gravityScale *=  prevMass / factor;
			yield return new WaitForSeconds(duration);
			rb2d.mass = prevMass;
			rb2d.gravityScale *= factor / prevMass;
			yield return null;
		}
	}
}

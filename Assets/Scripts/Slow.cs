using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

public class Slow : MonoBehaviour
{
	public float radius = 1;
	public float factor = 1;
	public float duration = 1;
	public int cost = 1;
	public Transform targetEffect;
	public Transform areaEffect;

	public void OnCast(Vector2 position)
	{
		if (!enabled || !gameObject.activeSelf)
			return;
		if (Mana.Instance.SpendMana(cost))
		{
			var instance = Instantiate(areaEffect, position, Quaternion.identity);
			instance.localScale *= factor;
			var hits = Physics2D.OverlapCircleAll(position, radius);
			if (hits != null)
			{
				foreach (var hit in hits)
				{
					StartCoroutine(ApplySlow(hit.transform));
				}
			}
		}
	}

	private IEnumerator ApplySlow(Transform target)
	{
		var rb2d = target.GetComponent<Rigidbody2D>();
		if (rb2d != null)
		{
			Instantiate(targetEffect, target.position, Quaternion.identity, target);
			var prevMass = rb2d.mass;
			rb2d.mass = factor;
			rb2d.velocity *= prevMass / factor;
			rb2d.gravityScale *= prevMass / factor;
			yield return new WaitForSeconds(duration);
			if (rb2d != null)
			{
				rb2d.mass = prevMass;
				rb2d.gravityScale *= factor / prevMass;
			}

			yield return null;
		}
	}
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{
	public int amount = 10;
	public int cost = 1;

	public void OnCast(Transform target)
	{
		if (!enabled || !gameObject.activeSelf)
			return;
		if (Mana.Instance.SpendMana(cost))
		{
			var health = target.GetComponent<Health>();
			if (health != null)
			{
				health.Heal(amount);
			}
			else
			{
				Mana.Instance.AddMana(cost);
			}
		}
	}
}

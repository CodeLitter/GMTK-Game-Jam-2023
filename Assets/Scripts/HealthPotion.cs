using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : MonoBehaviour
{
	public int amount;
	private void OnTriggerEnter2D(Collider2D other)
	{
		var health = other.GetComponent<Health>();
		if (health != null)
		{
			health.Heal(amount);
			gameObject.SetActive(false);
		}
	}
}

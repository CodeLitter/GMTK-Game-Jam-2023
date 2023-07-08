using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
	public int amount = 10;
	public float minimumTimeBetweenDamage = 2.0f;
	public UnityEvent onDeath;

	private float timeSinceLastDamageTaken = 0.0f;

	public int Max { get; private set; }

	private void Awake()
	{
		Max = amount;
	}

	private void Update()
	{
		if (amount > Max)
		{
			amount = Max;
		}
		if (amount <= 0)
		{
			onDeath.Invoke();
		}

		timeSinceLastDamageTaken += Time.fixedDeltaTime;
	}

	public bool TakeDamage(int value)
	{
		if (timeSinceLastDamageTaken >= minimumTimeBetweenDamage)
		{
			amount -= value;
			timeSinceLastDamageTaken = 0.0f;
			return true;
		}
		return false;
	}

	public void Heal(int value)
	{
		amount += value;
	}
}

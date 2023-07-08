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

	private int max;
	private float timeSinceLastDamageTaken = 0.0f;

	private void Awake()
	{
		max = amount;
	}

	private void Update()
	{
		if (amount > max)
		{
			amount = max;
		}
		if (amount <= 0)
		{
			onDeath.Invoke();
		}

		timeSinceLastDamageTaken += Time.fixedDeltaTime;
	}

	public bool takeDamage(int value)
	{
		if (timeSinceLastDamageTaken >= minimumTimeBetweenDamage)
		{
			amount -= value;
			timeSinceLastDamageTaken = 0.0f;
			return true;
		}
		return false;
	}
}

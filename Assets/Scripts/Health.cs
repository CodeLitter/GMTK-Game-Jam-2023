using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
	public int amount = 10;
	public float minimumTimeBetweenDamage = 2.0f;
	public UnityEvent onHurt;
	public UnityEvent onDeath;

	private float _timeSinceLastDamageTaken = 0.0f;
	private float _prevAmount;

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

		_timeSinceLastDamageTaken += Time.fixedDeltaTime;
	}

	private void LateUpdate()
	{
		if (amount < _prevAmount)
		{
			onHurt.Invoke();
		}

		_prevAmount = amount;
	}

	public bool TakeDamage(int value)
	{
		if (_timeSinceLastDamageTaken >= minimumTimeBetweenDamage)
		{
			amount -= value;
			_timeSinceLastDamageTaken = 0.0f;
			return true;
		}
		return false;
	}

	public void Heal(int value)
	{
		amount += value;
	}
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
	public int amount = 10;
	public UnityEvent onDeath;
	private int max;

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
	}
}

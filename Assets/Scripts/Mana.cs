using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mana : Singleton<Mana>
{
	public int amount = 10;

	public int Max { get; private set; }

	private void Awake()
	{
		Max = amount;
	}

	private void Update()
	{
		amount = Mathf.Clamp(amount, 0, Max);
	}

	public bool SpendMana(int cost)
	{
		if (amount > cost)
		{
			this.amount -= cost;
			return true;
		}

		return false;
	}

	public void AddMana(int cost)
	{
		this.amount += cost;
	}
}
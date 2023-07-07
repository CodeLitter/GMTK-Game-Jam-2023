using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{
	public int amount = 10;
	
	public void OnCast(Transform target)
	{
		var health = target.GetComponent<Health>();
		health.amount += amount;
	}
}

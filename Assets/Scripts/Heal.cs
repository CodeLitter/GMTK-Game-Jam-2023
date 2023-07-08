using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{
	public int amount = 10;
	
	public void OnCast(Transform target)
	{
		if (!enabled || !gameObject.activeSelf)
			return;
		target.transform.SendMessage("Heal", amount, SendMessageOptions.DontRequireReceiver);
	}
}

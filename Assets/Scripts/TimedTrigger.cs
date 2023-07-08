using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TimedTrigger : MonoBehaviour
{
	public float delay = 1;
	public UnityEvent onTrigger;

	private void Start()
	{
		StartCoroutine(Timer());
	}

	private IEnumerator Timer()
	{
		while (true)
		{
			yield return new WaitForSeconds(delay);
			onTrigger.Invoke();
		}
	}
}

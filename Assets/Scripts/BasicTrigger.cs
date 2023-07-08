using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class BasicTrigger : MonoBehaviour
{
	public UnityEvent onTrigger;
	private void OnTriggerEnter2D(Collider2D other)
	{
		onTrigger.Invoke();
	}

	private void OnCollisionEnter2D(Collision2D other)
	{
		onTrigger.Invoke();
	}
}

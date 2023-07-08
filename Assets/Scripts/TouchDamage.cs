using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

[RequireComponent(typeof(Collider2D))]
public class TouchDamage : MonoBehaviour
{
	public int amount = 1;
	public float force = 1;
	public float stunTime = 1;
	public string targetTag;
	public UnityEvent onHit;

    private void OnCollisionEnter2D(Collision2D other)
	{
		if (other.transform.CompareTag(targetTag))
		{
			var health = other.transform.GetComponent<Health>();
			if (health.takeDamage(amount))
			{
				health.StartCoroutine(Fling(other.transform));
				onHit.Invoke();
			}
		}
	}

	private IEnumerator Fling(Transform target)
	{
		target.GetComponent<Movement>().enabled = false;
		var rb2d = target.GetComponent<Rigidbody2D>();
		var direction = Vector3.Normalize(target.position - transform.position) + target.up;
		rb2d.AddForce(direction * force, ForceMode2D.Impulse);
		
		yield return new WaitForSeconds(stunTime);

		target.GetComponent<Movement>().enabled = true;

		yield return null;
	}
}
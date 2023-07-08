using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
	public Transform prefab;
	public float speed;

	public void Shoot()
	{
		var instance = Instantiate(prefab, transform.position, Quaternion.identity);
		instance.GetComponent<Rigidbody2D>().AddForce(transform.right * speed, ForceMode2D.Impulse);
	}
}

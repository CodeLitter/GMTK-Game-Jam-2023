using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimator : MonoBehaviour
{
	public Animator animator;
	public Rigidbody2D rigidbody2D;
	private static readonly int IsMoving = Animator.StringToHash("IsMoving");

	private void Awake()
	{
		animator = animator ? animator : GetComponent<Animator>();
		rigidbody2D = rigidbody2D ? rigidbody2D : GetComponent<Rigidbody2D>();
	}

	private void Update()
	{
		animator.SetBool(IsMoving, Mathf.Abs(rigidbody2D.velocity.x) > 0.1f);
	}

	public void TriggerCast()
	{
		animator.SetTrigger("Cast");
	}

	public void TriggerHurt()
	{
		animator.SetTrigger("Hurt");
	}

	public void TriggerDeath()
	{
		animator.SetTrigger("Death");
	}
}
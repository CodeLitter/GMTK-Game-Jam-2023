using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpellSwitcher : MonoBehaviour
{
	private void Start()
	{
		SelectSpell(0);
	}

	public void SelectSpell(int index)
	{
		var spell = transform.GetChild(index);
		foreach (Transform child in transform)
		{
			child.gameObject.SetActive(false);
		}
		spell.gameObject.SetActive(true);
	}
	
	public void OnSelectSpell(InputValue value)
	{
		var index = (int) value.Get<float>() - 1;
		SelectSpell(index);
	}
}

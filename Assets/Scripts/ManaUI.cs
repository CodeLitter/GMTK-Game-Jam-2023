using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaUI : MonoBehaviour
{
	public Slider slider;

	private void Update()
	{
		slider.value = Mana.Instance.amount / (float) Mana.Instance.Max;
	}
}
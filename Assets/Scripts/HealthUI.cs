using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
	public Health health;
	public Slider slider;

	private void Update()
	{
		slider.value = health.amount / (float)health.Max;
	}
}

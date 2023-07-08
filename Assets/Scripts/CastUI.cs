using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CastUI : MonoBehaviour
{
	public Cast cast;
	public Slider slider;

	private void Update()
	{
		slider.value = cast.CooldownTimeElapsed / cast.cooldown;
	}
}

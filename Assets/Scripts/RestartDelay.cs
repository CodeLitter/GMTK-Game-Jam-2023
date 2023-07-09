using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartDelay : MonoBehaviour
{
	public float delay = 3;
	public void Restart()
	{
		StartCoroutine(_Restart());
	}

	private IEnumerator _Restart()
	{
		yield return new WaitForSeconds(delay);
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		yield return null;
	}
}

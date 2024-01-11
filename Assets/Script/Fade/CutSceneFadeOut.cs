using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CutSceneFadeOut : MonoBehaviour
{
	Image image;
	[SerializeField] float endTime;
	[SerializeField] string sceneName;

	void Start()
	{
		image = GetComponent<Image>();
		StartCoroutine(FadeOutCoroutine());
	}

	IEnumerator FadeOutCoroutine()
	{
		yield return new WaitForSeconds(endTime);

		for (int i = 0; i < 100; ++i)
		{
			yield return new WaitForSeconds(0.01f);
			image.color += new Color(0, 0, 0, 0.01f);
		}

		SceneManager.LoadScene(sceneName);
	}
}
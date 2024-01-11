using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeChange : MonoBehaviour
{
	Image image;

	void Start()
	{
		image = GetComponent<Image>();
	}

	public void FadeChangeFunction(string sceneName)
	{
		StartCoroutine(FadeOutCoroutine(sceneName));
	}

	IEnumerator FadeOutCoroutine(string sceneName)
	{
		for (int i = 0; i < 100; ++i)
		{
			yield return new WaitForSeconds(0.01f);
			image.color += new Color(0, 0, 0, 0.01f);
		}
		SceneManager.LoadScene(sceneName);
	}
}

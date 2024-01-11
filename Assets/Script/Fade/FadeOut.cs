using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour
{
	Image image;

	void Start()
	{
		image = GetComponent<Image>();
	}

	public void FadeOutFunction()
	{
		StartCoroutine(FadeOutCoroutine());
	}

	IEnumerator FadeOutCoroutine()
	{
		for (int i = 0; i < 100; ++i)
		{
			yield return new WaitForSeconds(0.01f);
			image.color += new Color(0, 0, 0, 0.01f);
		}
	}
}

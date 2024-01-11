using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{
    Image image;

    void Start()
    {
        image = GetComponent<Image>();
        StartCoroutine(FadeInCoroutine());
    }

	IEnumerator FadeInCoroutine()
	{
		for (int i = 0; i < 100; ++i)
		{
			yield return new WaitForSeconds(0.01f);
			image.color -= new Color(0, 0, 0, 0.01f);
		}
	}
}
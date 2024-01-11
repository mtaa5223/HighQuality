using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MpaTextUnderbar : MonoBehaviour
{
	Image image;

	bool apear = false;

	void Start()
	{
		image = GetComponent<Image>();
		image.color = new Color(1, 1, 1, 0);
	}

	void Update()
	{
		if (image.color.a < 1 && !apear)
		{
			image.color += new Color(0, 0, 0, Time.deltaTime * 0.3f);
		}
		else if (image.color.a >= 1 && !apear)
		{
			apear = true;
		}
		else
		{
			image.color += new Color(0, 0, 0, Time.deltaTime * -0.4f);
		}
	}
}
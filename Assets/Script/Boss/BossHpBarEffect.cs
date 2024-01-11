using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHpBarEffect : MonoBehaviour
{
    Image image;
    bool fulled = false;

    void Start()
    {
        image = GetComponent<Image>();
    }

    void Update()
    {
        if (!fulled)
        {
			image.fillAmount += Time.deltaTime * 0.1f;
		}
        if (image.fillAmount >= 1)
        {
            fulled = true;
        }
    }
}

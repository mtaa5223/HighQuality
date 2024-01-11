using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MapText : MonoBehaviour
{
    TextMeshProUGUI textMeshPro;

    bool apear = false;

    void Start()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();
        textMeshPro.color = new Color(1, 1, 1, 0);
    }

    void Update()
    {
        if (textMeshPro.color.a < 1 && !apear)
        {
            textMeshPro.color += new Color(0, 0, 0, Time.deltaTime * 0.3f);
        }
        else if (textMeshPro.color.a >= 1 && !apear)
        {
            apear = true;
        }
        else
        {
			textMeshPro.color += new Color(0, 0, 0, Time.deltaTime * -0.4f);
		}
    }
}

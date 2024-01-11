using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeApear : MonoBehaviour
{
    [SerializeField] float time;
    float timer = 0;

    TextMeshProUGUI textMeshProUGUI;

	private void Start()
	{
        textMeshProUGUI = GetComponent<TextMeshProUGUI>();
	}

	void Update()
    {
        timer += Time.deltaTime;
        if (timer >= time)
        {
            textMeshProUGUI.enabled = true;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestText : MonoBehaviour
{
    [SerializeField] string mainText;
    public string extraText;

	TextMeshProUGUI textMeshProUGUI;

	float allEnemy;

	void Start()
    {
        textMeshProUGUI = GetComponent<TextMeshProUGUI>();
        allEnemy = GameManager.instance.remainEnemy;
    }

    void Update()
    {
        if (extraText == null)
        {
            textMeshProUGUI.text = mainText + " " + (allEnemy - GameManager.instance.remainEnemy).ToString() + " / " + allEnemy.ToString();
        }
        else
        {
			textMeshProUGUI.text = mainText + " " + (allEnemy - GameManager.instance.remainEnemy).ToString() + " / " + allEnemy.ToString() + "\n" + extraText;
		}
    }
}
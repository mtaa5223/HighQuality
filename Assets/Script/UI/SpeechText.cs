using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpeechText : MonoBehaviour
{
    [TextArea]
    public string[] texts;

    [SerializeField] GameObject speechText;

    TextMeshProUGUI textMeshPro;

    float time = 0f;
    int count = 0;

    float writeTime = 0f;
    int writeCount = 0;

    void Start()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        time += Time.deltaTime;
        if (count >= texts.Length && speechText != null)
        {
            speechText.SetActive(true);
        }
        else if (time >= 2f && count < texts.Length && writeCount > texts[count].Length)
        {
            textMeshPro.text = "";
            time = 0f;
            count++;
            writeCount = 0;
        }
        else if (time > 2f && count < texts.Length)
        {
            writeTime += Time.deltaTime;
            if (writeTime > 0.05f)
            {
                textMeshPro.text = texts[count].Substring(0, writeCount);
                writeCount++;
                writeTime -= 0.05f;
                if (writeCount > texts[count].Length)
                {
                    time = 0f;
                    writeTime = 0f;
                }
            }
        }
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Capture : MonoBehaviour
{
    [SerializeField] string title;

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            ScreenCapture.CaptureScreenshot(title + DateTime.Now.ToString("_yyyyMMdd_HHmm") + ".png");
        }
    }
}
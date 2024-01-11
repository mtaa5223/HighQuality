using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutsceneChanger : MonoBehaviour
{
    [SerializeField] int endTime;
    [SerializeField] string sceneName;

    float timer = 0;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= endTime)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
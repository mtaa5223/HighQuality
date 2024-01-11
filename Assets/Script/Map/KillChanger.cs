using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillChanger : MonoBehaviour
{
    [SerializeField] string sceneName;

    bool chaged = false;

    void Update()
    {
        if (GameManager.instance.remainEnemy <= 0 && !chaged)
        {
            chaged = true;
            GetComponent<FadeChange>().FadeChangeFunction(sceneName);
        }
    }
}
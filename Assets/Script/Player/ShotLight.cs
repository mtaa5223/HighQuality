using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotLight : MonoBehaviour
{
    float time = 0;

    void Update()
    {
        time += Time.deltaTime;
        if (time > 0.01f)
        {
            Destroy(gameObject);
        }
    }
}
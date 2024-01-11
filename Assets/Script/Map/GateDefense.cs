using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateDefense : MonoBehaviour
{
    void Update()
    {
        if (GameManager.instance.remainEnemy <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
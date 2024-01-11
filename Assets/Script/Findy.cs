using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Findy : MonoBehaviour
{
    public Transform gun;

    void Update()
    {
        transform.position = gun.position;
    }
}
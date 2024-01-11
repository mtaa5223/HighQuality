using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderRandomPosition : MonoBehaviour
{
    public Transform player;

    void Start()
    {
        transform.position = new Vector3(Mathf.Clamp(player.position.x + Random.Range(-10f, 10f), -35f, 35f), 19, Mathf.Clamp(player.position.z + Random.Range(-10f, 10f), -35f, 35f));
        transform.localEulerAngles = new Vector3(0, Random.Range(0, 360), 0);
    }
}
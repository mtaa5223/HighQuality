using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderTargetPosition : MonoBehaviour
{
    public Transform player;

    void Start()
    {
        transform.position = new Vector3(player.position.x, 18, player.position.z);
		transform.localEulerAngles = new Vector3(0, Random.Range(0, 360), 0);
	}
}
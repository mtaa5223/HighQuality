using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCanvas : MonoBehaviour
{
    Transform target;

	private void Start()
	{
		target = transform.parent.GetComponent<MonsterAi>().target;
	}

	private void Update()
    {
        transform.LookAt(Camera.main.transform.position);
    }
}
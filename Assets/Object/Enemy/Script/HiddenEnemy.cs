using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenEnemy : MonoBehaviour
{
	public GameObject enemy_1;
	public GameObject enemy_2;

	bool spawned = false;

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player" && !spawned)
		{
			enemy_1.SetActive(true);
			enemy_2.SetActive(true);
			spawned = true;
		}
	}
}

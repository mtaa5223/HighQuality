using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillAttack : MonoBehaviour
{
	// Start is called before the first frame update
	private void OnTriggerEnter(Collider other)
	{
		Debug.Log("1");
		if (other.gameObject.CompareTag("Player"))
		{
			GameManager.instance.playerHp -= 50;
		}
	}
}

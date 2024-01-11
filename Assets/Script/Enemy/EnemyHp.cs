using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyHp : MonoBehaviour
{
	public int hp = 3;
	public bool executed = false;


	Animator animator;


	private void Start()
	{
		animator = GetComponent<Animator>();
	}
	public void EnemyDie()
	{
		StartCoroutine(EnemyDieCoroutine());
	}

	IEnumerator EnemyDieCoroutine()
	{
		yield return new WaitForSeconds(5);
		Destroy(gameObject);
	}
}
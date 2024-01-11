using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAttack : MonoBehaviour
{
    Animator animator;

	public bool onPlayer = false;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

	private void Update()
	{
		if (onPlayer)
		{
			animator.SetTrigger("Attack");
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			onPlayer = true;
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			onPlayer = false;
		}
	}

	public void AttackPlayer()
	{
		if (onPlayer)
		{
			GameManager.instance.LosePlayerHp(50);
		}
	}
}
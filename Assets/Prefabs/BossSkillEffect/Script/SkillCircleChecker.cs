using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillCircleChecker : MonoBehaviour
{
    [SerializeField] float appearTime;
    [SerializeField] float disappearTime;
    [SerializeField] int damage;

    CapsuleCollider collider;

    float time = 0;

	private void Start()
	{
        collider = GetComponent<CapsuleCollider>();
	}

	void Update()
    {
        time += Time.deltaTime;

        if (time >= appearTime)
        {
            collider.enabled = true;
        }
        if (time >= disappearTime)
        {
            Destroy(gameObject);
        }
    }

	private void OnTriggerEnter(Collider other)
	{
        if (other.CompareTag("Player"))
        {
            GameManager.instance.LosePlayerHp(damage);
        }
		if (other.CompareTag("Enemy"))
		{
			Debug.Log("Die");
			other.GetComponent<MonsterAi>().EnemyDie();
		}
	}
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRandomSpawn : MonoBehaviour
{
    [SerializeField] GameObject enemy;

    float time = 0f;

    void Update()
    {
        if (time < 15f)
        {
			time += Time.deltaTime;
			if (GameManager.instance.remainEnemy < 3 && time >= 15f)
			{
				GameObject spawnEnemy = Instantiate(enemy);
				spawnEnemy.transform.position = new Vector3(Random.Range(-23f, 23f), 19, Random.Range(-23f, 23f));
				spawnEnemy.transform.parent = transform;
				GameManager.instance.remainEnemy++;
				spawnEnemy.SetActive(true);
				time = 0f;
			}
		}
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //적 오브젝트
    [SerializeField] GameObject enemy;

    //스폰 주기
    [SerializeField] float spawnTime = 20;

    [SerializeField] int spawnCount = 0;

    //소환 범위
    [SerializeField] float randomRangeX;
    [SerializeField] float rangeY;
    [SerializeField] float randomRangeZ;

    [SerializeField] bool immediatelyMove = false;

	int count = 0;
    float time = 0;

    void Update()
    {
        time += Time.deltaTime;
        if (time >= spawnTime && count < spawnCount)
        {
            EnemySpawn();
            EnemySpawn();
            time -= spawnTime;
            count++;
        }
    }

    void EnemySpawn()
    {
		GameObject spawnEnemy = Instantiate(enemy);
        spawnEnemy.transform.position = transform.position + new Vector3(Random.Range(-randomRangeX, randomRangeX), rangeY, Random.Range(-randomRangeZ, randomRangeZ));

		float speed = Random.Range(2f, 4f);
		spawnEnemy.GetComponent<MonsterAi>().defaultSpeed = speed;
        spawnEnemy.GetComponent<MonsterAi>()._moveSpeed = immediatelyMove ? speed : 0;

		int hp = Random.Range(2, 4);
		spawnEnemy.GetComponent<EnemyHp>().hp = hp;

        spawnEnemy.transform.parent = transform;

		spawnEnemy.SetActive(true);
	}
}
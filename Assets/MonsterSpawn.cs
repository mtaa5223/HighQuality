using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawn : MonoBehaviour
{
    float currTime;

    bool spawngage = false;
    public GameObject Monster;
    // Update is called once per frame
    void Start()
    {
        MSpawn();
    }

    void MSpawn()
    {
        if (!spawngage)
        {
            StartCoroutine(Spawn());
        }
    }
    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(5f);

        float newX = Random.Range(-80f, -90f), newY = Random.Range(9f, 9f), newZ = Random.Range(-35f, -37f);

        GameObject monster = Instantiate(Monster);

        monster.transform.position = new Vector3(newX, newY, newZ);
        spawngage = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestComplete : MonoBehaviour
{
    void Update()
    {
        if (GameManager.instance.remainEnemy <= 0)
        {
            GetComponent<QuestText>().extraText = "출구에서 몰려오는 적들을 막으세요. (완료)";
		}
    }
}

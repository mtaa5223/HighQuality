using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestComplete : MonoBehaviour
{
    void Update()
    {
        if (GameManager.instance.remainEnemy <= 0)
        {
            GetComponent<QuestText>().extraText = "�ⱸ���� �������� ������ ��������. (�Ϸ�)";
		}
    }
}

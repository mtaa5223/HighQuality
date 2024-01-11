using ECM.Examples;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmergencyOn : MonoBehaviour
{
	[SerializeField] GameObject[] activeObjects;
	[SerializeField] AudioSource soundManager;
	[SerializeField] AudioClip emergencySound; //�����
	[SerializeField] Transform emergencySpawner; //�̸����� ������
	[SerializeField] QuestText questText; //���� ��


	bool emergencyAble = false;
	bool emergencyOned = false;

	private void Update()
	{
		if (emergencySpawner.childCount == 4)
		{
			emergencyAble = true;
		}
		if (emergencySpawner.childCount == 0 && emergencyAble && !emergencyOned)
        {
			for (int i = 0; i < activeObjects.Length; ++i)
			{
				activeObjects[i].SetActive(true);

            }
			emergencyOned = true;
			soundManager.clip = emergencySound;
			soundManager.Play();
			questText.extraText = "�ⱸ���� �������� ������ ��������. (�̿Ϸ�)";
        }
	}
}
using ECM.Examples;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmergencyOn : MonoBehaviour
{
	[SerializeField] GameObject[] activeObjects;
	[SerializeField] AudioSource soundManager;
	[SerializeField] AudioClip emergencySound; //경고음
	[SerializeField] Transform emergencySpawner; //이머전시 스포너
	[SerializeField] QuestText questText; //남은 적


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
			questText.extraText = "출구에서 몰려오는 적들을 막으세요. (미완료)";
        }
	}
}
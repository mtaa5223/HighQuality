using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeText : MonoBehaviour
{
	[SerializeField] SpeechText speechText;

	string[] texts = { "", "������ �����ϱ� ������ �Ϻ����� ���߳�����. �׳༮�� ���������� �����ؾ���" };

	bool added = false;

	private void OnTriggerEnter(Collider other)
	{
		if (!added)
		{
			speechText.texts = texts;
			added = true;
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeText : MonoBehaviour
{
	[SerializeField] SpeechText speechText;

	string[] texts = { "", "봉인을 성공하긴 했지만 완벽하진 못했나보군. 그녀석이 나오기전에 정리해야해" };

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

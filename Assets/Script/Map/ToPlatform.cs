using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToPlatform : MonoBehaviour
{
	[SerializeField] FadeChange fade;
	[SerializeField] string sceneName;

	bool loaded = false;

	private void OnTriggerStay(Collider other)
	{
		if (other.CompareTag("Player") && GameManager.instance.remainEnemy <= 0 && !loaded)
		{
			fade.FadeChangeFunction(sceneName);
			loaded = true;
		}
	}
}
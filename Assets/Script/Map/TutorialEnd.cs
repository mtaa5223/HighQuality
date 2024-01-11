using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialEnd : MonoBehaviour
{
	public FadeChange fade;

	bool loaded = false;

	private void OnCollisionStay(Collision collision)
	{
		if (collision.gameObject.CompareTag("Player") && GameManager.instance.remainEnemy <= 0 && !loaded)
		{
			fade.FadeChangeFunction("1_ToBridge");
		}
	}
}
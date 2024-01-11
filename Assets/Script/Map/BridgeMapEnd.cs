using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BridgeMapEnd : MonoBehaviour
{
	public FadeChange fade;

	bool loaded = false;

	private void OnCollisionStay(Collision collision)
	{
		if (collision.gameObject.CompareTag("Player") && GameManager.instance.remainEnemy <= 0 && !loaded)
		{
			fade.FadeChangeFunction("3_ToTrainStation");
		}
	}
}
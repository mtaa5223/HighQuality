using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWall : MonoBehaviour
{
	[SerializeField] GameObject wall;

	void Start()
	{
		for (int i = 0; i < 9; ++i)
		{
			GameObject prefabWall = Instantiate(wall);
			prefabWall.transform.SetParent(transform);
			transform.eulerAngles = new Vector3(0, i * 10, 0);
		}
	}
}
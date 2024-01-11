using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBackMove : MonoBehaviour
{
	[SerializeField] Transform cameraPlace;

    void Update()
    {
		transform.position = cameraPlace.position;
		transform.Translate(Vector3.right * 0.5f);
		transform.rotation = cameraPlace.rotation;
	}
}

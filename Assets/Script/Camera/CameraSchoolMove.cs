using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSchoolMove : MonoBehaviour
{
	[SerializeField] Transform cameraPlace;

    void Update()
    {
		transform.position = cameraPlace.position;
		transform.Translate(Vector3.right * 0.5f);
		transform.position = new Vector3(Mathf.Clamp(transform.position.x, 5, 9), cameraPlace.position.y, cameraPlace.position.z);
		transform.rotation = cameraPlace.rotation;
	}
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] Transform cameraPlace;

	void Update()
    {
        transform.position = cameraPlace.position;
    }
}
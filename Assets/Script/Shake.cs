using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static CartoonFX.CFXR_Effect;

public class Shake : MonoBehaviour
{
	CameraShake cameraShake;
	// Start is called before the first frame update
	void Start()
    {
        cameraShake.StartShake();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCastSound : MonoBehaviour
{
	[SerializeField] float appearTime;

	AudioSource audioSource;

    float time = 0;
	bool sounded = false;

	void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
		time += Time.deltaTime;

		if (time >= appearTime && !sounded)
		{
			audioSource.Play();
			sounded = true;
		}
    }
}

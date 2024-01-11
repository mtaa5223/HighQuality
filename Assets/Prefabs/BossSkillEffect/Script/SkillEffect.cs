using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillEffect : MonoBehaviour
{
    [SerializeField] float appearTime;
    [SerializeField] float disappearTime;

    ParticleSystem particleSystem;

    float time = 0;
    bool played = false;

	private void Start()
	{
        particleSystem = GetComponent<ParticleSystem>();
	}

	void Update()
    {
        time += Time.deltaTime;

        if (time >= appearTime && !played)
        {
            particleSystem.Play();
            played = true;
        }
        if (time >= disappearTime)
        {
            Destroy(gameObject);
        }
    }
}
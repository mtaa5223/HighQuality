using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillZone : MonoBehaviour
{
    [SerializeField] float appearTime;
    [SerializeField] float disappearTime;

	MeshRenderer meshRenderer;

    float time = 0;

	private void Start()
	{
        meshRenderer = GetComponent<MeshRenderer>();
	}

	void Update()
    {
        time += Time.deltaTime;

        if (time >= appearTime)
        {
            meshRenderer.enabled = true;
        }
        if (time >= disappearTime)
        {
            Destroy(gameObject);
        }
    }
}
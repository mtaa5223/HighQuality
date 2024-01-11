using UnityEngine;

public class MuzzleFlash : PoolAble
{
    private ParticleSystem particleSystem;

    [HideInInspector] public Transform firePos;

    private float time = 0f;

    private void Awake()
    {
        particleSystem = GetComponent<ParticleSystem>();
    }

    void OnEnable()
    {
        particleSystem.Play();
        time = 0f;
    }

    private void Update()
    {
        transform.position = firePos.position;

        time += Time.deltaTime;
        if (time >= 1f)
        {
            Release();
        }
    }
}
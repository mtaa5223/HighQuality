using UnityEngine;

public class ShakerDestroyer : PoolAble
{
    float time = 0;

    private void OnEnable()
    {
        time = 0;
    }

    void Update()
    {
        time += Time.deltaTime;
        if (time >= 3f)
        {
            Release();
        }
    }
}

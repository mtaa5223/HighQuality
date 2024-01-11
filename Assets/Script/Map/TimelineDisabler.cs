using Cinemachine;
using UnityEngine;

public class TimelineDisabler : MonoBehaviour
{
    [SerializeField] private GameObject[] disableobjects;
    [SerializeField] private GameObject[] activeobjects;

    [Space(10)]
    [SerializeField] CinemachineVirtualCamera virtualCamera;
    [SerializeField] Transform player;

    public void DisableObjects()
    {
        for (int i = 0; i < disableobjects.Length; ++i)
        {
            disableobjects[i].SetActive(false);
        }
        for (int i = 0; i < activeobjects.Length; ++i)
        {
            activeobjects[i].SetActive(true);
        }
        virtualCamera.LookAt = player;
    }
}
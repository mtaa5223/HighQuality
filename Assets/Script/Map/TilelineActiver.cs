using Cinemachine;
using UnityEngine;

public class TilelineActiver : MonoBehaviour
{
    [Tooltip("Timeline Directer")]
    [SerializeField] GameObject directer;
    [SerializeField] int remainEnemy;

    [Space(10)]
    [SerializeField] CinemachineVirtualCamera virtualCamera;
    [SerializeField] Transform lookAtObject;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player") && GameManager.instance.remainEnemy <= remainEnemy)
        {
            virtualCamera.LookAt = lookAtObject;
            directer.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
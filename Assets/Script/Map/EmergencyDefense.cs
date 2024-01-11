using ECM.Examples;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmergencyDefense : MonoBehaviour
{
    public GameObject player;

    private Vector3 defaultIronDoor;
    public Transform ironDoor;

	public FollowCameraController mainCamera;

    public GameObject[] enemys;

    public GameObject playerUi;

	bool close = false;

	private void Start()
	{
        defaultIronDoor = ironDoor.position;
        playerUi.SetActive(false);
	}

	void Update()
    {
        if (close)
        {
            ironDoor.position = Vector3.MoveTowards(ironDoor.position, defaultIronDoor + new Vector3(0, 5, 0), 2f * Time.deltaTime);
            if (ironDoor.position.y >= (defaultIronDoor + new Vector3(0, 4, 0)).y)
            {
				mainCamera.distanceToTarget = 11;
				playerUi.SetActive(true);
				Destroy(gameObject);
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(-28, 0, -115), 4f * Time.deltaTime);
            if (transform.position.z == -115)
            {
				close = true;
				for (int i = 0; i < enemys.Length; ++i)
                {
                    enemys[i].SetActive(true);
                }
            }
		}
	}
}

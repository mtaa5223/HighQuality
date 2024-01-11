using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IronDoor : MonoBehaviour
{
    public Transform ironDoor;

    private Vector3 closeDoor; //문 기본값
    public Vector3 openDoor; //문 열림값

    bool playerOn = false;

	private void Start()
	{
        closeDoor = ironDoor.position;
	}

	void Update()
    {
        if (playerOn)
        {
            ironDoor.position = Vector3.MoveTowards(ironDoor.position, closeDoor + new Vector3(0, 7, 0), 5f * Time.deltaTime);
        }
        else
        {
            ironDoor.position = Vector3.MoveTowards(ironDoor.position, closeDoor, 5f * Time.deltaTime);
		}
    }

	private void OnTriggerEnter(Collider other)
	{
        if (other.gameObject.CompareTag("Player"))
        {
            playerOn = true;
        }
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			playerOn = false;
		}
	}
}

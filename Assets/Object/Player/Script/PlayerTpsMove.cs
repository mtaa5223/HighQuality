using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTpsMove : MonoBehaviour
{
    public float rotSpeed = 200f;

    public float speed = 5f;
    Rigidbody rigidbody;
    private Rigidbody rb;
    float mx = 0;
    public bool executing = false;

    void Start()
    {
        GameManager.instance.isTps = true;
        //마우스 중앙 고정
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
		rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (!executing)
        {
            float moveX = Input.GetAxis("Horizontal");
            float moveZ = Input.GetAxis("Vertical");
            Vector3 movement = transform.TransformDirection(new Vector3(moveX, 0f, moveZ)) * speed * Time.deltaTime;
            transform.position += movement;
            float mouse_X = Input.GetAxis("Mouse X");

            mx += mouse_X * rotSpeed * Time.deltaTime;

            transform.eulerAngles = new Vector3(0, mx, 0);
        }
    }
}
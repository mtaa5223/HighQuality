using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBackMove : MonoBehaviour
{
    public float speed = 5f;
    Rigidbody rigidbody;
    UnityEngine.Ray cameraRay;
    public GameObject mainBoss;
    private Rigidbody rb;

    public bool boss = false;

    public GameObject sideCamera;
    public GameObject sideCamearaPlace;
    public GameObject tpsCamera;

    Plane plane;

    float rayLength;
    Vector3 lookPoint;

    public GameObject spawn2;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Debug.Log("1111");
        rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        //플레이어 이동
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical) * speed * Time.deltaTime;

        rb.MovePosition(transform.position + movement);

        //플레이어 회전
        float point = Input.mousePosition.x;
        Debug.Log(((point / 1920f - 0.5f) * 180f).ToString());
        if (new Vector3(point * 180, 0, 0) != Vector3.zero)
        {
            transform.rotation = Quaternion.Euler(0, (point / 1920f - 0.5f) * 180f, 0);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("JANGA"))
        {
            transform.position = new Vector3(-91, 10, -36); 
            sideCamera.SetActive(false);
            sideCamearaPlace.SetActive(false);
            tpsCamera.SetActive(true);
            Cursor.lockState = CursorLockMode.Locked;


            transform.GetComponent<PlayerTpsMove>().enabled = true;
            transform.GetComponent<PlayerBackMove>().enabled = false;

        }

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("JANGA2"))
        {
            Debug.Log("태어난다");
            boss = true;
            spawn2.SetActive(true);
            mainBoss.SetActive(true);


        }

    }

}
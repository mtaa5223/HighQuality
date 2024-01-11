using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rotato : MonoBehaviour
{
    void Update()
    {
        transform.eulerAngles += new Vector3(0, 50 * Time.deltaTime, 0);
        if (Input.GetMouseButtonUp(0))
        {
			SceneManager.LoadScene("Tutorial");
		}
    }
}
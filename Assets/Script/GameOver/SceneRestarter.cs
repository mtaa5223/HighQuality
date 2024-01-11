using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneRestarter : MonoBehaviour
{
    void Update()
    {
        if (GameManager.instance.playerHp <= 0)
        {
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
    }
}
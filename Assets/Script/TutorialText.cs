using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialText : MonoBehaviour
{
    [SerializeField] private EnemyHp enemyHp;

    [SerializeField] private GameObject texted;
    [SerializeField] private GameObject excuteText;
    [SerializeField] private GameObject endText;

    private bool excuteEnabled = false;
    private bool endEnabled = false;

    void Update()
    {
        if (!excuteEnabled && enemyHp.hp <= 0)
        {
            texted.SetActive(false);
            excuteText.SetActive(true);
            excuteEnabled = true;
        }

        if (!endEnabled && enemyHp == null)
        {
            excuteText.SetActive(false);
            endText.SetActive(true);
            endEnabled = true;
        }
    }
}
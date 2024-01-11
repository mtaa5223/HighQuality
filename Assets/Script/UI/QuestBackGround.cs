using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestBackGround : MonoBehaviour
{
    RectTransform rectTransform;

    float targetX = 240;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.K))
        {
            targetX = -targetX;
        }
        if (rectTransform.position.x < targetX)
        {
            rectTransform.position += new Vector3(40, 0, 0);

        }
        else if (rectTransform.position.x > targetX)
        {
			rectTransform.position -= new Vector3(40, 0, 0);
		}
    }
}
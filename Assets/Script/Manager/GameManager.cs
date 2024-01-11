using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	public static GameManager instance = null; //���� �Ŵ���

	[SerializeField] Animator playerAnimator; //�÷��̾� �ִϸ�����

	[SerializeField] Image playerHurt; //�÷��̾� ü�¹�

	[Space(10)]
	[SerializeField] GameObject pauseCanvas; //�Ͻ����� ȭ��

	[Space(10)]
	public float playerHp = 100; //�÷��̾� ü��

	public float remainEnemy = 0;

	[Space(10)]
	public Transform player;
	public Transform firePos;

	private float timer = 0;

	[HideInInspector] public bool isTps = false;

	private void Awake()
	{
		if (instance == null)
		{
            instance = this;
        }
        else
		{
			Destroy(gameObject);
		}
        //UnityEngine.Rendering.DebugManager.instance.enableRuntimeUI = false;
    }

    private void Start()
    {
		if (!isTps)
		{
            Cursor.visible = true;
			Cursor.lockState = CursorLockMode.None;
        }
    }

    void Update()
    {
		//�÷��̾� ü�� ���
		if (playerHp < 100)
		{
			timer += Time.deltaTime;
			if (timer > 3)
			{
				playerHp++;
				timer -= 3;
			}
		}
		else
		{
			timer = 0;
		}

		//ü�� UI
		playerHurt.color = new Vector4(1, 1, 1, 1 - playerHp / 100f);

		if (Input.GetKeyUp(KeyCode.Escape))
		{
			if (pauseCanvas.activeSelf)
			{
                if (isTps)
                {
                    Cursor.visible = false;
                    Cursor.lockState = CursorLockMode.Locked;
                }
                pauseCanvas.SetActive(false);
                Time.timeScale = 1f;
			}
			else
			{
                if (isTps)
                {
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.None;
                }
                pauseCanvas.SetActive(true);
                Time.timeScale = 0f;
            }
		}
    }

	//ü�°��� �ڷ�ƾ ���� �Լ�
	public void LosePlayerHp(float damage)
	{
		StartCoroutine(losingHp(damage));
	}

	//ü�°��� �ڷ�ƾ
	IEnumerator losingHp(float damage)
	{
		if (playerHp - damage <= 0f)
		{
			playerAnimator.SetTrigger("Die");
		}
		else
		{
			for (int i = 0; i < damage; ++i)
			{
				playerHp -= 1f;
				if (playerHp <= 0f)
				{
					playerAnimator.SetTrigger("Die");
				}
				yield return new WaitForSeconds(0.01f);
			}
		}
	}
}
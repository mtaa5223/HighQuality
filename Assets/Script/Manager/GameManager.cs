using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	public static GameManager instance = null; //게임 매니저

	[SerializeField] Animator playerAnimator; //플레이어 애니메이터

	[SerializeField] Image playerHurt; //플레이어 체력바

	[Space(10)]
	[SerializeField] GameObject pauseCanvas; //일시정지 화면

	[Space(10)]
	public float playerHp = 100; //플레이어 체력

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
		//플레이어 체력 재생
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

		//체력 UI
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

	//체력감소 코루틴 실행 함수
	public void LosePlayerHp(float damage)
	{
		StartCoroutine(losingHp(damage));
	}

	//체력감소 코루틴
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
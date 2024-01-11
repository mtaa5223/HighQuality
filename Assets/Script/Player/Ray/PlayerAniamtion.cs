using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerAniamtion : MonoBehaviour
{
    int playerAngleRange = 0;
    int moveDirection = 0;

    float moveAngle = 0;
    float playerAngle = 0;

	[SerializeField] GameObject player;
	[SerializeField] GameObject gun;

	[SerializeField] GameObject sword;

	[SerializeField] GameObject headSpectrum; //잔상
	[SerializeField] GameObject bodySpectrum; //잔상
	[SerializeField] GameObject legSpectrum; //잔상

    [SerializeField] ParticleSystem skill; //스킬

	[SerializeField] GunShot reLoad;
    [SerializeField] GameObject gunShot;

	public bool killing = false;

    Vector3 originPos;

    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {

		transform.rotation = transform.parent.transform.rotation;
		transform.position = player.transform.position;

        animator.SetBool("FrontMove", false);
        animator.SetBool("RightMove", false);
        animator.SetBool("LeftMove", false);
        animator.SetBool("BackMove", false);
        animator.SetBool("Idle", false);

        if (Input.GetKey(KeyCode.W) && (moveDirection == 0 || moveDirection == 1))
        {
            RotatePlayer("FrontMove", "RightMove", "LeftMove", "BackMove");
            moveDirection = 1;
        }
        else if (Input.GetKey(KeyCode.D) && (moveDirection == 0 || moveDirection == 2))
        {
            RotatePlayer("RightMove", "BackMove", "FrontMove", "LeftMove");
            moveDirection = 2;
        }
        else if (Input.GetKey(KeyCode.A) && (moveDirection == 0 || moveDirection == 3))
        {
            RotatePlayer("LeftMove", "FrontMove", "BackMove", "RightMove");
            moveDirection = 3;
        }
        else if (Input.GetKey(KeyCode.S) && (moveDirection == 0 || moveDirection == 4))
        {
            RotatePlayer("BackMove", "RightMove", "LeftMove", "FrontMove");
            moveDirection = 4;
        }
        else
        {
            animator.SetBool("Idle", true);
            moveDirection = 0;
        }
    }

    void RotatePlayer(string front, string left, string right, string back)
    {
        moveAngle = player.transform.rotation.y;
        if (-0.125f <= moveAngle && moveAngle <= 0.125f)
        {
            animator.SetBool(front, true);
        }
        else if (-0.75f <= moveAngle && moveAngle <= -0.25f)
        {
            animator.SetBool(left, true);
        }
        else if (0.25f <= moveAngle && moveAngle <= 0.75f)
        {
            animator.SetBool(right, true);
        }
        else
        {
            animator.SetBool(back, true);
        }

    }

	private void OnTriggerStay(Collider other)
	{
        //플레이어 체력 최대일때만 실행
        //적 처형 코드
        if (other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
			int enemyHp = other.GetComponent<EnemyHp>().hp;

            if (enemyHp <= 0 && Input.GetKeyDown(KeyCode.F) && !other.GetComponent<EnemyHp>().executed && !killing && !reLoad.reLoad)
            {
				transform.rotation = player.transform.rotation;

				killing = true;
				gun.SetActive(false);
				sword.SetActive(true);
				transform.parent.GetComponent<PlayerMove>().speed = 0;

				//플레이어 이동
				originPos = transform.parent.position;
                StartCoroutine(ExecutingMove(originPos, new Vector3(other.transform.position.x, originPos.y, other.transform.position.z) + transform.parent.forward * -1.7f));

                //잔상 생성
                StartCoroutine(DelaySpectrum());

                if (transform.parent.GetComponent<PlayerMove>() != null)
                {
                    transform.parent.GetComponent<PlayerMove>().executing = true;
                }
                if (transform.parent.GetComponent<PlayerTpsMove>() != null)
                {
                    transform.parent.GetComponent<PlayerTpsMove>().executing = true;
                }

				switch (Random.Range(0, 2))
				{
					case 0:
						animator.SetTrigger("Attack1");
						break;
					case 1:
						animator.SetTrigger("Attack2");
						break;
				}
                other.GetComponent<MonsterAi>().EnemyDie();

				other.GetComponent<EnemyHp>().executed = true;
				other.gameObject.GetComponent<EnemyHp>().EnemyDie();
			}
		}
	}

    //처형 완료
    public void AttackEnd()
    {
		transform.localRotation = Quaternion.identity;
		gun.SetActive(true);
		sword.SetActive(false);

        //잔상 제거
        SpectrumRemove();

		//플레이어 복귀
		StartCoroutine(ExecutingMove(transform.parent.position, originPos));
		transform.parent.position = originPos;

        if (transform.parent.GetComponent<PlayerMove>() != null)
        {
            transform.parent.GetComponent<PlayerMove>().speed = 3;
            transform.parent.GetComponent<PlayerMove>().executing = false;
        }
        if (transform.parent.GetComponent<PlayerTpsMove>() != null)
        {
            transform.parent.GetComponent<PlayerTpsMove>().executing = false;
        }
		killing = false;
	}

	//잔상 제거
	void SpectrumRemove()
    {
		for (int i = 0; i < headSpectrum.transform.childCount; ++i)
		{
			headSpectrum.transform.GetChild(i).gameObject.SetActive(false);
		}
		headSpectrum.SetActive(false);

		for (int i = 0; i < bodySpectrum.transform.childCount; ++i)
		{
			bodySpectrum.transform.GetChild(i).gameObject.SetActive(false);
		}
		bodySpectrum.SetActive(false);

		for (int i = 0; i < legSpectrum.transform.childCount; ++i)
		{
			legSpectrum.transform.GetChild(i).gameObject.SetActive(false);
		}
		legSpectrum.SetActive(false);
	}

    public void AngleSet()
    {
        Debug.Log("CoMe BAck");
		transform.localRotation = Quaternion.identity;
	}

    public void Dead()
    {
        animator.SetBool("Dead", true);
        gunShot.SetActive(false);
        if (transform.parent.GetComponent<PlayerMove>() != null)
        {
			transform.parent.GetComponent<PlayerMove>().enabled = false;
		}
        if (transform.parent.GetComponent<PlayerTpsMove>() != null)
        {
			transform.parent.GetComponent<PlayerTpsMove>().enabled = false;
            transform.parent.GetComponent<CapsuleCollider>().height = 0.2f;
		}
        SpectrumRemove();
    }

    public void GameOver()
    {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	//플레이어 이동
	IEnumerator ExecutingMove(Vector3 originPos, Vector3 toGoPos)
    {
        float runTime = 0f;

        while (runTime < 0.1f)
        {
            runTime += Time.deltaTime;
			transform.parent.position = Vector3.Lerp(originPos, toGoPos, runTime / 0.1f);
			yield return null;
        }
	}

    //잔상 생성
    IEnumerator DelaySpectrum()
    {
        yield return new WaitForSeconds(0.3f);
		headSpectrum.SetActive(true);
		bodySpectrum.SetActive(true);
		legSpectrum.SetActive(true);
	}
}
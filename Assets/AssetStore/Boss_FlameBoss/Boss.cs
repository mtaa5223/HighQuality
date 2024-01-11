using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using Unity.VisualScripting;

public class Boss : MonoBehaviour
{
	[SerializeField] Transform player;

	[SerializeField] GameObject slashSkill;
	[SerializeField] GameObject spikeSkill;

	[SerializeField] GameObject thunderSkill;
    [SerializeField] GameObject targetThunderSkill;
	[SerializeField] GameObject raidenSkill;

    [SerializeField] FadeChange fadeChange;

    [SerializeField] Image bossHpBar;

    [SerializeField] GameObject enemySpawner;

	private Animator animator;

	private NavMeshAgent agent = null;

	private AudioSource audioSource;

	bool skilltrade = false;

    bool born = false;
    bool stand = false;
    float coolTime = 0;

    bool attacking = false;

    int randoAnim = 0;
    int randoAnim2 = 0;

    int phase = 1; //보스 페이즈

    bool useRaiden = false; //라이덴 스킬 사용여부

	bool bossDead = false; //보스 사망여부


	Vector3 destination;

	void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        audioSource = GetComponent<AudioSource>();

		destination = agent.destination;

		this.transform.LookAt(player);
	}

    void Update()
    {
        //페이즈 1 스킬
        if (!attacking && born && phase == 1 && Vector3.Distance(transform.position, player.position) <= 15f)
        {
            coolTime += Time.deltaTime;
            if (coolTime > 2)
            {
                BossAnim();
                coolTime = 0;
            }
        }

        //페이즈 2 스킬
        if (!attacking && stand && phase == 2 && GetComponent<EnemyHp>().hp > 0 && !useRaiden)
        {
            coolTime += Time.deltaTime;
            if (coolTime > 2)
            {
                BossAnim2();
                coolTime = 0;
            }
        }

        if (useRaiden && Vector3.Distance(transform.position, player.position) <= 15f)
        {
			StartCoroutine(BornAttack2());
            useRaiden = false;
		}

        //페이즈 2 진입
        if (phase == 1 && GetComponent<EnemyHp>().hp < 100)
        {
            phase = 2;
			animator.SetTrigger("Born");
		}

        //보스 사망
        if (GetComponent<EnemyHp>().hp <= 0 && !bossDead)
        {
            agent.speed = 0;
            bossHpBar.fillAmount = 0;
            animator.SetTrigger("Die");
            audioSource.Play();
            Destroy(enemySpawner);
            bossDead = true;
        }
        //보스 이동
        else if (Vector3.Distance(destination, player.position) > 0f && player != null && !attacking && (born || stand))
		{
            if (phase == 1)
            {
                if (Vector3.Distance(transform.position, player.position) > 15f)
                {
                    agent.speed = 3f;
                }
                else
                {
                    agent.speed = 0.5f;
                }
            }
            if (phase == 2)
            {
                if (GetComponent<EnemyHp>().hp <= 0)
                {
                    agent.speed = 0;
                }
				else if (useRaiden)
				{
					agent.speed = 7;
				}
                else
                {
                    agent.speed = 2;
                }
			}
			destination = player.position;
			agent.destination = destination;
			//animator.SetBool("Run", true);
		}

        if (GetComponent<EnemyHp>().hp > 0 && born)
        {
            bossHpBar.fillAmount = GetComponent<EnemyHp>().hp / 200f;
		}
	}


    void BossAnim()
    {
        attacking = true;
        randoAnim = Random.Range(2, 4);
        
        switch (randoAnim)
        {
            case 2:
                StartCoroutine(Attack1());
                break;
            case 3:
                StartCoroutine(Attack2());
                break;
        }
    }

    void BossAnim2()
    {
		randoAnim2 = Random.Range(2, 4);
		switch (randoAnim2)
		{
			case 2:
				StartCoroutine(BornAttack1());
				break;
			case 3:
                useRaiden = true;
                break;
		}
    }

	IEnumerator Attack1()
    {
        animator.SetTrigger("Att1");
        InstantiateSkill(slashSkill);

        yield return new WaitForSeconds(5f);
        attacking = false;
    }

    IEnumerator Attack2()
    {
        animator.SetTrigger("Att2");
		InstantiateSkill(spikeSkill);

        yield return new WaitForSeconds(5f);
        attacking = false;


    }

    IEnumerator BornAttack1()
    {
		attacking = true;
		animator.SetTrigger("skill1");

        //유도 천둥 소환
		GameObject skillInstantiate = Instantiate(targetThunderSkill);
		skillInstantiate.transform.position = new Vector3(transform.position.x, 19, transform.position.z);
		skillInstantiate.transform.rotation = transform.rotation;
        skillInstantiate.GetComponent<ThunderTargetPosition>().player = player;

        for (int i = 0; i < 10; ++i)
        {
            skillInstantiate = Instantiate(thunderSkill);
            skillInstantiate.transform.position = new Vector3(transform.position.x, 19, transform.position.z);
            skillInstantiate.transform.rotation = transform.rotation;
            skillInstantiate.GetComponent<ThunderRandomPosition>().player = player;
        }

        yield return new WaitForSeconds(5f);
        attacking = false;

    }

    IEnumerator BornAttack2()
    {
		attacking = true;
		animator.SetTrigger("skill2");
		InstantiateSkill(raidenSkill);

		yield return new WaitForSeconds(5f);
        attacking = false;
    }

    void InstantiateSkill(GameObject skillObject)
    {
        GameObject skillInstantiate = Instantiate(skillObject);
        skillInstantiate.transform.position = new Vector3(transform.position.x, 19, transform.position.z);
        skillInstantiate.transform.rotation = transform.rotation;
	}

    public void Borned()
    {
        StartCoroutine(borning());
    }

    IEnumerator borning()
    {
        yield return new WaitForSeconds(3);
        GetComponent<EnemyHp>().hp = 200;
		born = true;
	}

    public void Stand()
    {
        stand = true;
    }

    public void Dead()
    {
        fadeChange.FadeChangeFunction("14_Ending");
	}
}
using UnityEngine;
using UnityEngine.AI;

public class MonsterAi : MonoBehaviour
{
    public Transform target;
    Vector3 destination;

    public Animator animator;

    private NavMeshAgent agent;

    float reviveTime = 0;

    public float defaultSpeed = 2;
    public float _moveSpeed = 0;
    [SerializeField] GameObject killZone;

    int defaultHp = 3;

    bool enemyDied = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        destination = agent.destination;
        defaultHp = GetComponent<EnemyHp>().hp;

        //킬존 사이즈 설정
        killZone.transform.parent = null;
        killZone.transform.localScale += new Vector3(1.9f, 0, 1.9f);
        killZone.transform.parent = transform;
    }

    void Update()
    {
        agent.speed = _moveSpeed;

        int hp = GetComponent<EnemyHp>().hp;

        if (enemyDied)
        {
            _moveSpeed = 0;
            killZone.SetActive(false); //처형범위 숨김
        }
        else if (hp <= 0)
        {
            if (reviveTime >= 10)
            {
                _moveSpeed = defaultSpeed;
                reviveTime = 0;
                GetComponent<EnemyHp>().hp = defaultHp;
                animator.SetBool("Faint", false);
                killZone.SetActive(false); //처형범위 숨김
            }
            else
            {
                _moveSpeed = 0;
                reviveTime += Time.deltaTime;
                animator.SetBool("Faint", true);
                killZone.SetActive(true); //처형범위 표시
            }
        }
        else if (Vector3.Distance(destination, target.position) > 0f && target != null)
        {
            destination = target.position;
            agent.destination = destination;
            animator.SetBool("Run", true);
        }
        else
        {
            animator.SetBool("Run", true);
        }

    }

    public void EnemyMove()
    {
        _moveSpeed = defaultSpeed;
    }

    public void EnemyDie()
    {
        GameManager.instance.remainEnemy--;
        enemyDied = true;
        animator.SetTrigger("Die");
    }
}
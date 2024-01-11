using UnityEngine;

public class Shot : PoolAble
{
    public float weaponRange = 5000f;

    public Transform firePos;

    public GameObject enemy;
    public Transform player;

    Vector3 startPosition;
    Vector3 endPosition;

    LineRenderer lineRenderer;

    float count = 0;

    void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    private void OnEnable()
    {
        firePos = GameManager.instance.firePos;
        player = GameManager.instance.player;

        Ray ray = new Ray(firePos.position, player.forward);

        RaycastHit hit = new RaycastHit();

        startPosition = firePos.position; //시작 위치 설정

        lineRenderer.SetPosition(0, startPosition); //레이저 시작 위치 설정
        lineRenderer.SetPosition(1, startPosition); //레이저 종료 위치 설정

        //레이어 관통 판정
        int layerMask = ((1 << LayerMask.NameToLayer("EnemyDetection")) | (1 << LayerMask.NameToLayer("TransparentWall")));
        layerMask = ~layerMask;

        if (Physics.Raycast(ray, out hit, weaponRange, layerMask))
        {
            if (hit.transform.gameObject.layer == LayerMask.NameToLayer("Enemy"))
            {
                if (hit.transform.gameObject.layer == LayerMask.NameToLayer("Enemy"))
                {
                    hit.transform.GetComponent<EnemyHp>().hp--;
                }
            }
            endPosition = hit.point;
        }
        else
        {

            endPosition = firePos.position + (player.forward * weaponRange);
        }

        lineRenderer.enabled = true;
        count = 0f;
    }

    void FixedUpdate()
    {
        if (count < Vector3.Distance(startPosition, endPosition))
        {
            lineRenderer.SetPosition(1, Vector3.MoveTowards(Vector3.MoveTowards(lineRenderer.GetPosition(0), endPosition, 0.3f), endPosition, 1f));
            lineRenderer.SetPosition(0, Vector3.MoveTowards(lineRenderer.GetPosition(0), endPosition, 1f));
            count++;
        }
        else
        {
            Release();
        }
    }
}
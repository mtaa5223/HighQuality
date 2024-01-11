using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController characterController;

    [SerializeField] float smoothness;
    [SerializeField] Animator anim;
    [SerializeField] float moveSpeed = 3.0f;
    [SerializeField] float dashSpeed = 5.0f;
    [SerializeField] float dashCooldown = 5.0f;
    [SerializeField] float rotationSpeed = 10.0f; // 추가된 부분

    [SerializeField] private GameObject Gun;
    [SerializeField] private GameObject Sword;

    public bool isExecuting;

    public Vector3 moveDirection;
    float horizontal;
    float vertical;
    float mathffloat_X;
    float mathffloat_Y;

    public bool moveCheck = false;
    private float lastDashTime; // 추가된 부분

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        lastDashTime = -dashCooldown; // 대시 쿨다운 초기화

    }

    void Update()
    {
        Animators();
        Dash();
        RotatePlayerWithMouse();
    }

    void Animators()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        mathffloat_X = Mathf.Lerp(mathffloat_X, horizontal, smoothness * Time.deltaTime);
        mathffloat_Y = Mathf.Lerp(mathffloat_Y, vertical, smoothness * Time.deltaTime);
        anim.SetFloat("Velocity_X", mathffloat_X);
        anim.SetFloat("Velocity_Y", mathffloat_Y);

        moveDirection = new Vector3(horizontal, 0, vertical);
        characterController.Move(moveDirection * moveSpeed * Time.deltaTime);
    }

    void Dash()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && moveDirection != Vector3.zero)
        {

            anim.SetBool("Roll", true);

            lastDashTime = Time.time;
        }
        else
        {

            anim.SetBool("Roll", false);
        }
    }

    void RotatePlayerWithMouse()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        int layerMask = ~(1 << 12);

        if (Physics.Raycast(ray, out hit, 100f, layerMask))
        {
            Vector3 targetPosition = new Vector3(hit.point.x, transform.position.y, hit.point.z);
            Quaternion toRotation = Quaternion.LookRotation(targetPosition - transform.position);
            transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
    }
    public void Attack(Animator enemyAnimator)
    {
        if (Input.GetKey(KeyCode.F) && !isExecuting)
        {
            anim.SetBool("Execute", true);
            enemyAnimator.SetTrigger("Die");
            rotationSpeed = 0f;
            moveSpeed = 0f;
            isExecuting = true;
        }
        //if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Execute"))
        //{
        //    rotationSpeed = 10f;
        //    moveSpeed = 3f;
        //}
        //else
        //{
        //    rotationSpeed = 0f;
        //    moveSpeed = 0f;
        //}
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Attack(other.GetComponent<MonsterAi>().animator);
        }
    }
}
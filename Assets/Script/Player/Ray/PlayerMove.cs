using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Rigidbody rigidbody;
    Vector3 velocity;
    UnityEngine.Ray cameraRay;
    Plane plane;
    float rayLength;
    Vector3 lookPoint;
    private float dashCoolTime = 5f;

    public int speed = 3;

    public bool executing = false;

    [SerializeField] private bool isBoss = false;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (!executing)
        {
            if (isBoss)
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit, 100))
                {
                    lookPoint = new Vector3(hit.point.x, transform.position.y, hit.point.z);
                    Vector3 lookDir = lookPoint - transform.position;
                    Vector3 rotateDir = new Vector3(lookDir.x, 0, lookDir.z);
                    rigidbody.MoveRotation(Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(rotateDir), Time.deltaTime * 40));
                }
            }
            else
            {
                cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
                plane = new Plane(Vector3.up, Vector3.zero);
                if (plane.Raycast(cameraRay, out rayLength))
                {
                    lookPoint = new Vector3(cameraRay.GetPoint(rayLength).x, transform.position.y, cameraRay.GetPoint(rayLength).z);
                    Vector3 lookDir = lookPoint - transform.position;
                    Vector3 rotateDir = new Vector3(lookDir.x, 0, lookDir.z);
                    rigidbody.MoveRotation(Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(rotateDir), Time.deltaTime * 40));
                }
            }
        }

        velocity = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized * speed;
        dashCoolTime += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.LeftShift) && dashCoolTime >= 5f)
        {
            rigidbody.AddForce(new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized * speed * 2f, ForceMode.Impulse);
            dashCoolTime = 0;
        }
    }

    void FixedUpdate()
    {
        rigidbody.MovePosition(rigidbody.position + velocity * Time.fixedDeltaTime);
    }
}